using AutoMapper;
using FantasyRolAPI.Data;
using FantasyRolAPI.DTOs.CharacterDTOs;
using FantasyRolAPI.DTOs.ClassDTOs;
using FantasyRolAPI.Enums;
using FantasyRolAPI.Models;
using FantasyRolAPI.Services.UserServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FantasyRolAPI.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public CharacterService(IConfiguration configuration, AppDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _db = dbContext;
            _configuration = configuration;
        }

        public async Task<bool> AddAsync(Character character)
        {
            character.Bonuses = AddMissingBonuses(character.Bonuses);
            
            _db.Add(character);
            await _db.SaveChangesAsync();
            return true;
        }
        public async Task<CharacterMiniDTO> GetById(Guid CharacterId, Guid UserId)
        {
            var asDb = _db.Character.Where(c=>c.Id == CharacterId&& c.UserId == UserId);
            if (asDb == null)
            {
                return null;
            }
            var result = await _mapper.ProjectTo<CharacterMiniDTO>(asDb).FirstAsync();

            return result;
        }

        public async Task<Race> GetRaceById(Guid Id)
        {
            var asDb =await _db.Race.Where(r=>r.Id == Id).FirstOrDefaultAsync();
            
            return asDb;
        }

        public async Task<List<CharacterMiniDTO>> GetListCharacters(Guid Id,string filter)
        {
            var asDb = _db.Character.Where(c => c.UserId == Id);

            if (!String.IsNullOrWhiteSpace(filter))
            {
                asDb = asDb.Where(c =>
                    (c.Name != null && c.Name.Contains(filter)) ||
                    (c.Story != null && c.Story.Contains(filter)) ||
                    (c.Description != null && c.Description.Contains(filter)) ||
                    (c.Background != null && c.Background.Name != null && c.Background.Name.Contains(filter)) ||
                    (c.Background != null && c.Background.PersonalityTrait != null && c.Background.PersonalityTrait.Contains(filter)) ||
                    (c.CharacterClass != null && c.CharacterClass.Name != null && c.CharacterClass.Name.Contains(filter))
                );
            }

            var result = await _mapper.ProjectTo<CharacterMiniDTO>(asDb).ToListAsync();
            return result;

        }

        public List<Bonus> AddMissingBonuses(List<Bonus> bonuses)
        {
            List<Characteristics_Type> existingCharacteristics = bonuses.Select(b => b.characteristic).ToList();

            foreach (Characteristics_Type characteristic in Enum.GetValues(typeof(Characteristics_Type)))
            {
                if (!existingCharacteristics.Contains(characteristic))
                {
                    Bonus missingBonus = new Bonus
                    {
                        characteristic = characteristic,
                        bonusValue = 10
                    };
                    bonuses.Add(missingBonus);
                }
            }

            return bonuses;
        }

        private bool HasBonusForCharacteristic(List<Bonus> bonuses, Characteristics_Type characteristic)
        {
            foreach (Bonus bonus in bonuses)
            {
                if (bonus.characteristic == characteristic)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

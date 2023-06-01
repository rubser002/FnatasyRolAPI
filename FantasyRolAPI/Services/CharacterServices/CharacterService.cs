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
        public async Task<CharacterDetailsMiniDTO> GetCharacterDetailsById(Guid CharacterId, Guid UserId)
        {
            var asDb = _db.Character
            .Where(c => c.Id == CharacterId && c.UserId == UserId)
            .Include(c => c.CharacterRace)
                .ThenInclude(r => r.Ability)
            .Include(c => c.CharacterRace)
                .ThenInclude(r => r.Bonuses);
            if (asDb == null)
            {
                return null;
            }
            var result = await _mapper.ProjectTo<CharacterDetailsMiniDTO>(asDb).FirstAsync();

            return result;
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

        public async Task UpdateBonuses(List<Bonus> bonuses)
        {
            _db.UpdateRange(bonuses);
            await _db.SaveChangesAsync();
        }
        public async Task UpdateItems(List<Item> items)
        {
            _db.UpdateRange(items);
            await _db.SaveChangesAsync();
        }
        public async Task UpdateCharacter(Character character)
        {
            var asDb = await _db.Character
                .Where(c => c.Id == character.Id)
                .Include(b => b.Background)
                .FirstAsync();

            var backgroundId = asDb.Background.Id;

            
            _db.Entry(asDb.Background).State = EntityState.Detached;

            character.Background.Id = backgroundId;

            if (asDb != null)
            {
                asDb.Story = character.Story;
                asDb.Description = character.Description;
                asDb.Alignment = character.Alignment;
                asDb.Background = character.Background;
                asDb.CurrentSpellSlots = character.CurrentSpellSlots;
                asDb.ExperiencePoints = character.ExperiencePoints;
                asDb.Name = character.Name;
                asDb.Story = character.Story;

                _db.Update(asDb);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteSpellToCharacter(Guid characterId, Guid spellId)
        {
            var characterSpells = await _db.CharacterSpell
                .Where(cs => cs.CharacterId == characterId && cs.SpellId == spellId)
                .ToListAsync();

            _db.CharacterSpell.RemoveRange(characterSpells);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteItem(Guid itemGuid)
        {
            var items = await _db.Item
                .Where(cs => cs.Id == itemGuid)
                .ToListAsync();

            _db.Item.RemoveRange(items);
            await _db.SaveChangesAsync();
        }


        public async Task AddSpellToCharacter(Guid characterId, Guid spellId)
        {

            var characterSpell = new CharacterSpell()
            {
                CharacterId = characterId,
                SpellId = spellId
            };
            await _db.AddAsync(characterSpell);
            await _db.SaveChangesAsync();

        }
    }
}

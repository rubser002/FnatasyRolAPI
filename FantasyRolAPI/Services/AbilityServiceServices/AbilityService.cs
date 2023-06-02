using AutoMapper;
using FantasyRolAPI.Data;
using FantasyRolAPI.DTOs.AbilityDTO;
using FantasyRolAPI.DTOs.CharacterDTOs;
using FantasyRolAPI.DTOs.ClassDTOs;
using FantasyRolAPI.Models;
using FantasyRolAPI.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FantasyRolAPI.Services.NewFolder
{
    public class AbilityService : IAbilityService
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AbilityService(IConfiguration configuration, AppDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _db = dbContext;
            _configuration = configuration;
        }

        public async Task<List<AbilityMiniDTO>> GetAbilitiesFromClassLevel(Guid classId, int lvl)
        {
            var classAbilities = _db.Class
                .Where(c => c.Id == classId)
                .SelectMany(c => c.ClassAbilities)
                .Select(ca => ca.Ability).Where(a=>a.Level == lvl)
                ;
            var result = await _mapper.ProjectTo<AbilityMiniDTO>(classAbilities).ToListAsync();
            return result;
        }


        public async Task<List<AbilityMiniDTO>> GetAbilitiesFromCharacter(Guid characterId)
        {
            var classAbilities =  _db.Character
                .Where(c => c.Id == characterId)
                .SelectMany(c => c.CharacterAbilities)
                .Select(ca => ca.Ability);
            var result =await _mapper.ProjectTo<AbilityMiniDTO>(classAbilities).ToListAsync();
            return result;
        }

        public async Task AddAbilitiesToCharacter(Guid characterId, List<Ability> abilities)
        {
            var existingAbilities = _db.CharacterAbility
                .Where(c => c.CharacterId == characterId)
                .ToList();

            foreach (var ability in abilities)
            {
                var existingAbility = existingAbilities
                    .FirstOrDefault(a => a.AbilityId == ability.Id);

                if (existingAbility != null)
                {
                    existingAbility.Ability.Name = ability.Name;
                    existingAbility.Ability.Description = ability.Description;

                    _db.CharacterAbility.Update(existingAbility);
                }
                else if(ability!=null)
                {
                    var newAbility = new Ability
                    {
                        Name = ability.Name,
                        Description = ability.Description,
                        Level = ability.Level,
                        Bonuses = ability.Bonuses,
                        Identifier= ability.Identifier,
                        
                    };

                    var characterAbility = new CharacterAbility
                    {
                        Ability = newAbility,
                        CharacterId = characterId
                    };

                    _db.CharacterAbility.Add(characterAbility);
                }
            }

            await _db.SaveChangesAsync();
        }

        public async Task UpdateAbilities(List<Ability> ability)
        {
            _db.UpdateRange(ability);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAbility(Guid abilityId)
        {
            var items = await _db.Ability
                .Where(cs => cs.Id == abilityId)
                .ToListAsync();

            _db.Ability.RemoveRange(items);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAbility(Ability ability)
        {
            _db.Update(ability);
            await _db.SaveChangesAsync();

        }
    }
}

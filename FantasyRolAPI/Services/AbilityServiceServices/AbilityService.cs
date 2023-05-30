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

        public AbilityService(IConfiguration configuration, AppDbContext dbContext)
        {
            _db = dbContext;
            _configuration = configuration;
        }

        public async Task<List<Ability>> GetAbilitiesFromClassLevel(Guid classId, int lvl)
        {
            var classAbilities = await _db.Class
                .Where(c => c.Id == classId)
                .SelectMany(c => c.ClassAbilities)
                .Select(ca => ca.Ability).Where(a=>a.Level == lvl)
                .ToListAsync();

            return classAbilities;
        }


        public async Task<List<Ability>> GetAbilitiesFromCharacter(Guid characterId)
        {
            var classAbilities = await _db.Character
                .Where(c => c.Id == characterId)
                .SelectMany(c => c.CharacterAbilities)
                .Select(ca => ca.Ability)
                .ToListAsync();

            return classAbilities;
        }

        public async Task AddAbilitiesToCharacter(Guid characterId, List<Ability> abilities)
        {
            
            var classObj = await _db.Character.FindAsync(characterId);
            foreach (var ability in abilities)
            {
                classObj.CharacterAbilities.Add(new CharacterAbility { Ability = ability });

            }
            _db.Update(classObj);
            _db.SaveChanges();

        }

    }
}

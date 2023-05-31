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

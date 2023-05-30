using FantasyRolAPI.DTOs.CharacterDTOs;
using FantasyRolAPI.DTOs.ClassDTOs;
using FantasyRolAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FantasyRolAPI.Services.NewFolder
{
    public interface IAbilityService 
    {
        Task<List<Ability>> GetAbilitiesFromClassLevel(Guid classId, int lvl);
        Task<List<Ability>> GetAbilitiesFromCharacter(Guid characterId);
        Task AddAbilitiesToCharacter(Guid characterId, List<Ability> abilities);
    }
}

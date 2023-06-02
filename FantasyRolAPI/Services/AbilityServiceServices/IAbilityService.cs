using FantasyRolAPI.DTOs.AbilityDTO;
using FantasyRolAPI.DTOs.CharacterDTOs;
using FantasyRolAPI.DTOs.ClassDTOs;
using FantasyRolAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FantasyRolAPI.Services.NewFolder
{
    public interface IAbilityService 
    {
        Task<List<AbilityMiniDTO>> GetAbilitiesFromClassLevel(Guid classId, int lvl);
        Task<List<AbilityMiniDTO>> GetAbilitiesFromCharacter(Guid characterId);
        Task AddAbilitiesToCharacter(Guid characterId, List<Ability> abilities);
        Task UpdateAbilities(List<Ability> ability);
        Task DeleteAbility(Guid abilityId);
        Task UpdateAbility(Ability ability);
    }
}

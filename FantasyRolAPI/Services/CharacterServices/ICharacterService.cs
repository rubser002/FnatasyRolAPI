using FantasyRolAPI.Models;

namespace FantasyRolAPI.Services.CharacterServices
{
    public interface ICharacterService
    {
        Task<bool> AddAsync(Character character);
    }
}

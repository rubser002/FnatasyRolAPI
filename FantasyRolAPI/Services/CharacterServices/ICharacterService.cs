using FantasyRolAPI.DTOs.CharacterDTOs;
using FantasyRolAPI.Models;

namespace FantasyRolAPI.Services.CharacterServices
{
    public interface ICharacterService
    {
        Task<bool> AddAsync(Character character);
        Task<CharacterMiniDTO> GetById(Guid Id);
        Task<Race> GetRaceById(Guid Id);
        Task<List<CharacterMiniDTO>> GetListCharacters(Guid Id, string filter);
    }
}

using FantasyRolAPI.DTOs.CharacterDTOs;
using FantasyRolAPI.Models;

namespace FantasyRolAPI.Services.CharacterServices
{
    public interface ICharacterService
    {
        Task<bool> AddAsync(Character character);
        Task<CharacterMiniDTO> GetById(Guid CharacterId, Guid UserId);
        Task<List<CharacterMiniDTO>> GetListCharacters(Guid Id, string filter);
        Task<CharacterDetailsMiniDTO> GetCharacterDetailsById(Guid CharacterId, Guid UserId);
        Task UpdateBonuses(List<Bonus> bonuses);
        Task UpdateItems(List<Item> items);
        Task DeleteSpellToCharacter(Guid characterId, Guid spellId);
        Task DeleteItem(Guid itemGuid);
        Task AddSpellToCharacter(Guid characterId, Guid spellId);
        Task UpdateCharacter(Character character);
    }
}

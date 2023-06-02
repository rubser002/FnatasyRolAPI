using Microsoft.AspNetCore.Mvc;

namespace FantasyRolAPI.Services.SpellServices
{
    public interface ISpellService 
    {
        Task<object> GetSpells(
            int pageSize = 10,
            int currentPage = 1,
            string filter = null,
            string level = null,
            string school = null,
            string description = null);


        Task AddSpellCharacter(Guid characterId, Guid spellId);
        Task DeleteSpellCharacter(Guid characterId, Guid spellId);
        Task<object> GetSpellsCharacter(
        Guid characterId,
        int pageSize = 10,
        int currentPage = 1,
        string filter = "",
        string level = "",
        string school = "",
        string description = "");
    }
}

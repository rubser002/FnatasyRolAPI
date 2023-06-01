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
    }
}

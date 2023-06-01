using AutoMapper;
using FantasyRolAPI.Services.NewFolder;
using FantasyRolAPI.Services.SpellServices;
using Microsoft.AspNetCore.Mvc;

namespace FantasyRolAPI.Controllers
{
    [Route("api/spell")]
    [ApiController]
    public class SpellController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly ISpellService _spellService;

        public SpellController(IConfiguration configuration, IMapper mapper, ISpellService spellService) : base(mapper)
        {
            _configuration = configuration;
            _spellService = spellService;
        }

        [HttpPost("GetSpells")]
        public async Task<IActionResult> GetSpells(int pageSize, int currentPage, string filter=null, string level = null, string school = null, string description = null)
        {
            try
            {
                
                var asView = await this._spellService.GetSpells(pageSize, currentPage, filter, level,school,description);

                if (asView != null)
                {
                    return Ok(asView);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

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
        public async Task<IActionResult> GetSpells(int pageSize, int currentPage, string filter="", string level = "", string school = "", string description = "")
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

        [HttpPost("GetSpellsCharacter")]
        public async Task<IActionResult> GetSpellsCharacter(Guid characterId,int pageSize, int currentPage, string filter = "", string level = "", string school = "", string description = "")
        {
            try
            {

                var asView = await this._spellService.GetSpellsCharacter(characterId, pageSize, currentPage, filter, level, school, description);

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

        [HttpPost("AddSpellCharacter")]
        public async Task<IActionResult> AddSpellCharacter(Guid characterId, Guid spellId)
        {
            try
            {
                await this._spellService.AddSpellCharacter(characterId, spellId);

                    return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DeleteSpellCharacter")]
        public async Task<IActionResult> DeleteSpellCharacter(Guid characterId, Guid spellId)
        {
            try
            {
                 await this._spellService.DeleteSpellCharacter(characterId, spellId);
                    return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}

using AutoMapper;
using FantasyRolAPI.DTOs.AbilityDTO;
using FantasyRolAPI.DTOs.CharacterDTOs;
using FantasyRolAPI.DTOs.ClassDTOs;
using FantasyRolAPI.Models;
using FantasyRolAPI.Services.AuthServices;
using FantasyRolAPI.Services.NewFolder;
using FantasyRolAPI.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace FantasyRolAPI.Controllers
{
    [Route("api/ability")]
    [ApiController]
    public class AbilityController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IAbilityService _abilityService;

        public AbilityController(IConfiguration configuration, IMapper mapper, IAbilityService abilityService) : base(mapper)
        {
            _configuration = configuration;
            _abilityService = abilityService;
        }

        [HttpPost("GetAbilitiesFromClass")]
        public async Task<IActionResult> GetAbilitiesFromClass(Guid classId, int lvl = 0)
        {
            try
            {
                
                var asView =await this._abilityService.GetAbilitiesFromClassLevel(classId, lvl);

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

        [HttpPost("GetAbilitiesFromCharacter")]
        public async Task<IActionResult> GetAbilitiesFromCharacter(Guid characterId)
        {
            try
            {
                var asView =await this._abilityService.GetAbilitiesFromCharacter(characterId);

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

        [HttpPost("AddAbilitiesToCharacter")]
        public async Task<IActionResult> AddAbilitiesToCharacter(Guid cahracterId, AbilityPostDTO[] abilitiesPost)
        {
            try
            {
                var abilities = new List<Ability>();
                foreach(AbilityPostDTO abilityPostDTO in abilitiesPost)
                {
                    var ability = _mapper.Map<Ability>(abilitiesPost);
                    abilities.Add(ability);
                }

                
                await this._abilityService.AddAbilitiesToCharacter(cahracterId, abilities);
                    return Ok();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

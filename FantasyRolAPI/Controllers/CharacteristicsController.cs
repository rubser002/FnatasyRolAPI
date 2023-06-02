using AutoMapper;
using FantasyRolAPI.DTOs.UserDTOs;
using FantasyRolAPI.DTOs;
using FantasyRolAPI.Models;
using FantasyRolAPI.Services.AuthServices;
using FantasyRolAPI.Services.CharacterServices;
using Microsoft.AspNetCore.Mvc;
using FantasyRolAPI.Services.CharacteristicsServices;

namespace FantasyRolAPI.Controllers
{
    [ApiController]
    [Route("api/characteristics")]
    public class CharacteristicsController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly ICharacterService _characterService;
        private readonly ICharacteristicsService _characteristicsService;
        public CharacteristicsController(IConfiguration configuration, IMapper mapper, ICharacterService characterService, ICharacteristicsService characteristicsService) : base (mapper)
        {
            _configuration = configuration;
            _characterService = characterService;
            _characteristicsService = characteristicsService;
        }

        [HttpPost("GetClassAbilities")]
        public async Task<IActionResult> GetClassAbilities(Guid classId, int classLevel)
        {
            try
            {
                   var abilities =  await _characteristicsService.getAbilityByClassLevel(classId, classLevel);
                    return Ok(abilities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetClassAutocomplete")]
        public async Task<IActionResult> GetClassAutocomplete()
        {
            try
            {
                var classes = await _characteristicsService.getClassAutocomplete();
                return Ok(classes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetRaceAutocomplete")]
        public async Task<IActionResult> GetRaceAutocomplete()
        {
            try
            {
                var races = await _characteristicsService.getRaceAutocomplete();
                return Ok(races);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GenerateData")]
        public async Task<IActionResult> generateData()
        {
            await _characteristicsService.generateData();
            return Ok();
        }

        [HttpPost("GetRaceById")]
        public async Task<IActionResult> GetRaceById(Guid Id)
        {
            try
            {
                var result = await _characteristicsService.GetRaceById(Id);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

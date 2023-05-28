using AutoMapper;
using FantasyRolAPI.DTOs.CharacterDTOs;
using FantasyRolAPI.Models;
using FantasyRolAPI.Services.AuthServices;
using FantasyRolAPI.Services.CharacterServices;
using FantasyRolAPI.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace FantasyRolAPI.Controllers
{
    [ApiController]
    [Route("api/characters")]
    public class CharacterController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly ICharacterService _characterService;
        public CharacterController(IConfiguration configuration, IMapper mapper, ICharacterService characterService) : base(mapper)
        {
            _configuration = configuration;
            _characterService = characterService;
        }


        [HttpPost("AddUser")]
        public IActionResult AddCharacter(CharacterPostDTO characterPostDto)
        {
            try
            {
                var character = _mapper.Map<Character>(characterPostDto);
                _characterService.AddAsync(character);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

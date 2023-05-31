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


        [HttpPost("AddCharacter")]
        public async Task<IActionResult> AddCharacterAsync(CharacterPostDTO characterPostDto)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(characterPostDto.Name))
                    return BadRequest();
                var character = _mapper.Map<Character>(characterPostDto);
                await _characterService.AddAsync(character);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("GetListCharacters")]
        public async Task<IActionResult> GetListCharacters(Guid UserId, string filter = "")
        {
            try
            {
                

                var characters = await _characterService.GetListCharacters(UserId, filter);
                return Ok(characters);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("GetCharacterById")]
        public async Task<IActionResult> GetCharacterByIdAsync(Guid Id)
        {
            try
            {
                
                var result =await _characterService.GetById(Id);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

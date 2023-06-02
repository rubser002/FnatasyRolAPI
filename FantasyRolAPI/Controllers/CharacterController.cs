using AutoMapper;
using FantasyRolAPI.DTOs.BonusDTOs;
using FantasyRolAPI.DTOs.CharacterDTOs;
using FantasyRolAPI.DTOs.ItemDTOs;
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
                
                return Ok(character.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("UpdateCharacter")]
        public async Task<IActionResult> UpdateCharacter(CharacterPostDTO characterPostDto)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(characterPostDto.Name))
                    return BadRequest();
                var character = _mapper.Map<Character>(characterPostDto);
                await _characterService.UpdateCharacter(character);

                return Ok(character.Id);
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("GetCharacterById")]
        public async Task<IActionResult> GetCharacterByIdAsync(Guid CharacterId, Guid UserId)
        {
            try
            {
                var result =await _characterService.GetById(CharacterId, UserId);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("GetCharacterDetailsById")]
        public async Task<IActionResult> GetCharacterDetailsById(Guid CharacterId, Guid UserId)
        {
            try
            {
                var result = await _characterService.GetCharacterDetailsById(CharacterId, UserId);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("UpdateBonuses")]
        public async Task<IActionResult> UpdateBonuses(List<BonusPostDTO> bonuses)
        {
            try
            {
                var bonusAsEntity = _mapper.Map<List<Bonus>>(bonuses);
                await _characterService.UpdateBonuses(bonusAsEntity);
                
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("UpdateItems")]
        public async Task<IActionResult> UpdateItems(List<ItemPostDTO> items)
        {
            try
            {
                var bonusAsEntity = _mapper.Map<List<Item>>(items);
                await _characterService.UpdateItems(bonusAsEntity);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPost("DeleteItem")]
        public async Task<IActionResult> DeleteItem(Guid itemId)
        {
            try
            {

                await _characterService.DeleteItem(itemId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        



    }
}

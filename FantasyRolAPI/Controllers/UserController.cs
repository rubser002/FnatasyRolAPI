using FantasyRolAPI.Models;
using FantasyRolAPI.Services.AuthServices;
using FantasyRolAPI.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace FantasyRolAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public UserController(IConfiguration configuration, IAuthService authService, IUserService userService)
        {
            _configuration = configuration;
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUserAsync(User user)
        {
            try
            {
                await _userService.AddUserAsync(user);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("UpdateUser")]

        public async Task<IActionResult> UpdateUserAsync(User user)
        {
            try
            {
                await _userService.UpdateUserAsync(user);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

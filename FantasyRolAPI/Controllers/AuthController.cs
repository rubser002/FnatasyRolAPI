using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FantasyRolAPI.Models;
using FantasyRolAPI.Services.AuthServices;
using FantasyRolAPI.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IAuthService authService;

    public AuthController(IConfiguration configuration, IAuthService authService, IUserService userService)
    {
        _configuration = configuration;
        this.authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(User user)
    {
        try
        {
            bool isAuthenticated = await authService.Login(user);

            if (isAuthenticated)
            {
                string token = GenerateToken(user.Email);
                return Ok(new { token });
            }

            return Unauthorized();
        }
        catch (Exception ex)
        {
            return Unauthorized(ex.Message);
        }
    }


    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(User user)
    {
        try
        {
            bool isRegistered = await authService.Register(user);

            if (isRegistered)
            {
                string token = GenerateToken(user.Email);
                return Ok(new { token });
            }

            return Unauthorized();
        }
        catch (Exception ex)
        {
            return Unauthorized(ex.Message);
        }
    }


    private string GenerateToken(string email)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, email)
            }),
            Expires = DateTime.UtcNow.AddMinutes(1), 
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}

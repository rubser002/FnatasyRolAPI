using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using FantasyRolAPI.Controllers;
using FantasyRolAPI.DTOs.UserDTOs;
using FantasyRolAPI.Models;
using FantasyRolAPI.Services.AuthServices;
using FantasyRolAPI.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

[Route("api/auth")]
[ApiController]
public class AuthController: BaseController
{
    private readonly IConfiguration _configuration;
    private readonly IAuthService authService;

    public AuthController(IConfiguration configuration, IMapper mapper, IAuthService authService, IUserService userService) : base( mapper)
    {
        _configuration = configuration;
        this.authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(UserPostDTO userPost)
    {
        try
        {
            var user = _mapper.Map<User>(userPost);

            bool isAuthenticated = await authService.Login(user);

            if (isAuthenticated)
            {
                string token = authService.GenerateToken(user.Email);
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
    public async Task<IActionResult> RegisterAsync(UserPostDTO userPost)
    {
        try
        {
            var user = _mapper.Map<User>(userPost);

            bool isRegistered = await authService.Register(user);

            if (isRegistered)
            {
                string token = authService.GenerateToken(user.Email);
                return Ok(new { token });
            }

            return Unauthorized();
        }
        catch (Exception ex)
        {
            return Unauthorized(ex.Message);
        }
    }


    [HttpGet("check-token")]
    public IActionResult CheckToken(string token)
    {
        bool isTokenValid = authService.IsTokenValid(token);

        if (isTokenValid)
        {
            return Ok(isTokenValid);
        }
        else
        {
            return Unauthorized();
        }
    }


}

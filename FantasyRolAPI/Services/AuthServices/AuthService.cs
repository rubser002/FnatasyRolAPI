using FantasyRolAPI.Data;
using FantasyRolAPI.Models;
using FantasyRolAPI.Services.UserServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FantasyRolAPI.Services.AuthServices
{
    public class AuthService: IAuthService
    {
        private readonly AppDbContext _db;
        private readonly IUserService userService;
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration, AppDbContext dbContext, IUserService userService)
        {
            _db = dbContext;
            this.userService = userService;
            _configuration = configuration;
        }

        public async Task<User> Login(User user)
        {
            var userDb = await userService.GetUserByEmail(user.Email);

            if (userDb != null)
            {
                bool isPasswordValid = VerifyPassword(user.Password, userDb.Password);
                if(isPasswordValid)
                    return userDb;
                
            }

            return null;
        }

        public async Task<User> Register(User user)
        {
            var dbUser =await userService.GetUserByEmail(user.Email);
            if (dbUser==null && IsPasswordValid(user.Password))
            {
                user.Password = HashPassword(user.Password);

                return await userService.AddUserAsync(user);
            }
            return null;
        }

        private bool IsPasswordValid(string password)
        {
            bool isValid = password.Length >= 7 && password.Any(char.IsUpper) && password.Any(char.IsDigit);

            if (!isValid)
            {
                throw new ArgumentException("Password must be at least 7 characters long and contain at least one uppercase letter and one number.");
            }

            return isValid;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            string hashedInput = HashPassword(password);
            return hashedInput == hashedPassword;
        }
        public bool IsTokenValid(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"])),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true, 
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                tokenHandler.ValidateToken(token, validationParameters, out _);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public string GenerateToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, email)
            }),
                Expires = DateTime.UtcNow.AddDays(14),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}

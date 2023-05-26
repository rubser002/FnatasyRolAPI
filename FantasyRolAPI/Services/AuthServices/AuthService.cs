using FantasyRolAPI.Data;
using FantasyRolAPI.Models;
using FantasyRolAPI.Services.UserServices;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace FantasyRolAPI.Services.AuthServices
{
    public class AuthService: IAuthService
    {
        private readonly AppDbContext _db;
        private readonly IUserService userService;

        public AuthService(AppDbContext dbContext, IUserService userService)
        {
            _db = dbContext;
            this.userService = userService;
        }

        public async Task<bool> Login(User user)
        {
            var userDb = await userService.GetUserByEmail(user.Email);

            if (userDb != null)
            {
                bool isPasswordValid = VerifyPassword(user.Password, userDb.Password);
                return isPasswordValid;
            }

            return false;
        }

        public async Task<bool> Register(User user)
        {
            if (IsPasswordValid(user.Password))
            {
                user.Password = HashPassword(user.Password);
                userService.AddUser(user);

                return true;
            }

            return false;
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

        public string HashPassword(string password)
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


    }
}

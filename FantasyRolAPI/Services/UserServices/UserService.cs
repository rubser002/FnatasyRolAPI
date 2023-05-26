using FantasyRolAPI.Data;
using FantasyRolAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FantasyRolAPI.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;

        public UserService(AppDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserById(Guid Id)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Id == Id);
        }
        public  void AddUser(User user)
        {
            if (!IsPasswordValid(user.Password))
            {
                throw new ArgumentException("Password must be at least 7 characters long and contain at least one uppercase letter and one number.");
            }

            string hashedPassword = HashPassword(user.Password);

            user.Password = hashedPassword;

            _db.Users.Add(user);
             _db.SaveChanges();
        }

        public  void UpdateUser(User user)
        {
            if (!IsPasswordValid(user.Password))
            {
                throw new ArgumentException("Password must be at least 7 characters long and contain at least one uppercase letter and one number.");
            }

            string hashedPassword = HashPassword(user.Password);

            user.Password = hashedPassword;

            _db.Users.Update(user);
             _db.SaveChanges();

        }

        public bool IsValidUser(string email, string password)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email == email);

            if (user != null)
            {

                bool isPasswordValid = VerifyPassword(password, user.Password);
                return isPasswordValid;
            }

            return false; 
        }

        private bool IsPasswordValid(string password)
        {
            if (password.Length < 7)
                return false;

            if (!password.Any(char.IsUpper))
                return false;

            if (!password.Any(char.IsDigit))
                return false;

            return true;
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

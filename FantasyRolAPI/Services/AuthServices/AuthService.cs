using FantasyRolAPI.Data;
using FantasyRolAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FantasyRolAPI.Services.AuthServices
{
    public class AuthService
    {
        private readonly AppDbContext db;
        public AuthService(AppDbContext dbContext)
        {
            db = dbContext;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await db.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> IsValidUser(string email, string password)
        {
            var User = await GetUserByEmail(email) != null;

            return true;
        }

    }
}

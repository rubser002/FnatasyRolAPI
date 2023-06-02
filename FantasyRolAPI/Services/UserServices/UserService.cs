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
        public async Task<User> AddUserAsync(User user)
        {
            
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            

            _db.Users.Update(user);
             await _db.SaveChangesAsync();
            return user;

        }

    }
}

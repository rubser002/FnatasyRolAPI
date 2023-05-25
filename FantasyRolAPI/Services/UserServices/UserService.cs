using FantasyRolAPI.Data;
using FantasyRolAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FantasyRolAPI.Services.UserServices
{
    public class UserService
    {
        public class UserService : IUserService
        {
            private readonly AppDbContext _db;

            public UserService(AppDbContext dbContext)
            {
                _db = dbContext;
            }

            public void AddUser(User user)
            {
                _db.Users.Add(user);
                _db.SaveChanges();
            }
        }
    }
    




    }
}

using FantasyRolAPI.Data;
using FantasyRolAPI.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace FantasyRolAPI.Services.SpellServices
{
    public class SpellService : ISpellService
    {
        private readonly AppDbContext _db;
        private readonly IUserService userService;
        private readonly IConfiguration _configuration;

        public SpellService(IConfiguration configuration, AppDbContext dbContext)
        {
            _db = dbContext;
            _configuration = configuration;
        }



    }
}

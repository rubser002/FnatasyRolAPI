using FantasyRolAPI.Data;
using FantasyRolAPI.Models;
using FantasyRolAPI.Services.UserServices;

namespace FantasyRolAPI.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private readonly AppDbContext _db;

        public CharacterService( AppDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<bool> AddAsync(Character character)
        {
            _db.Add(character);
            await _db.SaveChangesAsync();
            return true;
        }


    }
}

using FantasyRolAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FantasyRolAPI.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) 
        { 

        }

        public DbSet<User> Users { get; set; }
    }
}

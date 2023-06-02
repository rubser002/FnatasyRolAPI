using FantasyRolAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FantasyRolAPI.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Add seeding code here
            

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Ability> Ability { get; set; }
        public DbSet<Bonus> Bonus { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Weapon> Weapon { get; set; }
        public DbSet<Armor> Armor { get; set; }
        public DbSet<Race> Race { get; set; }
        public DbSet<Spell> Spell { get; set; }
        public DbSet<CharacterAbility> CharacterAbility { get; set; }
        public DbSet<CharacterSpell> CharacterSpell { get; set; }
        public DbSet<ClassAbility> ClassAbility { get; set; }
        public DbSet<Subclass> Subclass { get; set; }
        public DbSet<Background> Background { get; set; }
    }

}


//mysql > CREATE DATABASE mydatabase;
//Query OK, 1 row affected (0.04 sec)

//mysql > CREATE DATABASE fantasy_rol;
//Query OK, 1 row affected (0.01 sec)

//mysql > CREATE USER 'myuser'@'%' IDENTIFIED BY 'mypassword';
//Query OK, 0 rows affected (0.03 sec)

//mysql > GRANT ALL PRIVILEGES ON mydatabase.* TO 'myuser'@'%';
//Query OK, 0 rows affected (0.02 sec)

//mysql > FLUSH PRIVILEGES;
//Query OK, 0 rows affected (0.02 sec)

//mysql >

//  dotnet ef migrations add InitialMigration
//  dotnet ef database update


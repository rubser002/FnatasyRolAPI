using FantasyRolAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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


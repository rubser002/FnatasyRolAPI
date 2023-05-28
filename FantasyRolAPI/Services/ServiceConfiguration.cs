namespace FantasyRolAPI.Services
{
    using FantasyRolAPI.Data;
    using FantasyRolAPI.Services.AuthServices;
    using FantasyRolAPI.Services.CharacterServices;
    using FantasyRolAPI.Services.UserServices;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceConfiguration
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 28))));

             services.AddScoped<IAuthService, AuthService>();
             services.AddScoped<IUserService, UserService>();
             services.AddScoped<ICharacterService, CharacterService>();

        }
    }

}

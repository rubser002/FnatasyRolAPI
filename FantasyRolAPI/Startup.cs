﻿using FantasyRolAPI.Data;
using FantasyRolAPI.Services.AuthServices;
using FantasyRolAPI.Services.CharacteristicsServices;
using FantasyRolAPI.Services.CharacterServices;
using FantasyRolAPI.Services.ClassServices;
using FantasyRolAPI.Services.NewFolder;
using FantasyRolAPI.Services.SpellServices;
using FantasyRolAPI.Services.UserServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace FantasyRolAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddAutoMapper(typeof(Startup));

            // Retrieve connection string from configuration
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            // Add DbContext and configure Entity Framework Core for MySQL
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 28))));

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Add other services and dependencies
             services.AddScoped<IAuthService, AuthService>();
             services.AddScoped<IUserService, UserService>();
             services.AddScoped<ICharacteristicsService, CharacteristicsService>();
             services.AddScoped<ICharacterService, CharacterService>();
             services.AddScoped<IAbilityService, AbilityService>();
             services.AddScoped<ISpellService, SpellService>();
             services.AddScoped<IClassService, ClassService>();



            // Configure other dependencies and services

            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

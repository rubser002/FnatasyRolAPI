using AutoMapper;
using FantasyRolAPI.DTOs;
using FantasyRolAPI.DTOs.UserDTOs;
using FantasyRolAPI.Models;

namespace FantasyRolAPI.Mappers
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Configure mappings here
                cfg.CreateMap<User, UserMiniDTO>();
                cfg.CreateMap<User, UserPostDTO>();
                // Add any other mapping configurations
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}

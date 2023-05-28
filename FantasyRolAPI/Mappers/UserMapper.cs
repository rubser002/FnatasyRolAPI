using AutoMapper;
using FantasyRolAPI.DTOs;
using FantasyRolAPI.DTOs.UserDTOs;
using FantasyRolAPI.Models;

namespace FantasyRolAPI.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper() {
            CreateMap<User, UserMiniDTO>()
                .ReverseMap();
            CreateMap<User, UserPostDTO>()
                .ReverseMap();
            CreateMap<UserMiniDTO, User>()
                .ReverseMap();
            CreateMap<UserPostDTO, User>()
                .ReverseMap();


        }
    }
}

using AutoMapper;
using FantasyRolAPI.DTOs.ClassDTOs;
using FantasyRolAPI.Models;

namespace FantasyRolAPI.Mappers
{
    public class ClassMapper : Profile
    {
        public ClassMapper() {

            CreateMap<Class, ClassMiniDTO>()
                .ReverseMap();
            CreateMap<Class, ClassPostDTO>()
                .ReverseMap();
        }
    }
}

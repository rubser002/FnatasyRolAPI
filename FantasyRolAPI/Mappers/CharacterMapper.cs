using FantasyRolAPI.DTOs.UserDTOs;
using FantasyRolAPI.DTOs;
using FantasyRolAPI.Models;
using FantasyRolAPI.DTOs.CharacterDTOs;
using AutoMapper;

namespace FantasyRolAPI.Mappers
{
    public class CharacterMapper: Profile
    {
        public CharacterMapper()
        {
            CreateMap<Character, CharacterMiniDTO>()
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.CharacterClass.Name))
                .ReverseMap();
            CreateMap<Character, CharacterPostDTO>()
                
                .ReverseMap();
        }
    }
}

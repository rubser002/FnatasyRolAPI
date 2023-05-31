using FantasyRolAPI.DTOs.UserDTOs;
using FantasyRolAPI.DTOs;
using FantasyRolAPI.Models;
using FantasyRolAPI.DTOs.CharacterDTOs;
using AutoMapper;
using System.ComponentModel;
using FantasyRolAPI.DTOs.AbilityDTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace FantasyRolAPI.Mappers
{
    public class CharacterMapper: Profile
    {
        public CharacterMapper()
        {
            CreateMap<Character, CharacterMiniDTO>()
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.CharacterClass.Name))
                .ForMember(dest => dest.AlignmentDescription, opt => opt.MapFrom(src => GetEnumDescription(src.Alignment)))
                .ReverseMap();
            CreateMap<Character, CharacterPostDTO>()
        
                .ReverseMap();
        }

        private static string GetEnumDescription(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo != null)
            {
                var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attributes.Length > 0 ? attributes[0].Description : value.ToString();
            }

            return value.ToString();
        }
    }
}

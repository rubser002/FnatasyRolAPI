using AutoMapper;
using FantasyRolAPI.DTOs.SepllDTOs;
using FantasyRolAPI.Models;
using System.ComponentModel;

namespace FantasyRolAPI.Mappers
{
    public class SpellMapper: Profile
    {
        public SpellMapper() {
            CreateMap<Spell, SpellMiniDTO>()
                    .ForMember(dest => dest.SchoolDesc, opt => opt.MapFrom(src => src.School != null ? GetEnumDescription(src.School) : null))
                            .ReverseMap();
            CreateMap<Spell, SpellPostDTO>()
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

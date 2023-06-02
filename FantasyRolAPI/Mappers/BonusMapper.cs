using AutoMapper;
using FantasyRolAPI.DTOs.BonusDTOs;
using FantasyRolAPI.Models;
using System.ComponentModel;

namespace FantasyRolAPI.Mappers
{
    public class BonusMapper: Profile
    {
        public BonusMapper() 
        {
            CreateMap<Bonus, BonusMiniDTO>()
                .ForMember(dest => dest.characteristicDesc, opt => opt.MapFrom(src => GetEnumDescription(src.characteristic)))
                        .ReverseMap();
            CreateMap<Bonus, BonusPostDTO>()
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

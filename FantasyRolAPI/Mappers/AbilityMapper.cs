using AutoMapper;
using FantasyRolAPI.DTOs.AbilityDTO;
using FantasyRolAPI.Models;

namespace FantasyRolAPI.Mappers
{
    public class AbilityMapper: Profile
    {
        public AbilityMapper() {
            CreateMap<Ability, AbilityMiniDTO>()
                    .ReverseMap();
            CreateMap<Ability, AbilityPostDTO>()
                .ReverseMap();
            
        }
    }
}

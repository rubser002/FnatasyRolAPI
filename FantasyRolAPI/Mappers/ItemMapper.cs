using AutoMapper;
using FantasyRolAPI.DTOs.ItemDTOs;
using FantasyRolAPI.Models;
using System.ComponentModel;

namespace FantasyRolAPI.Mappers
{
    public class ItemMapper: Profile
    {
        public ItemMapper() {
            CreateMap<Item, ItemMiniDTO>()
                            .ReverseMap();
            CreateMap<Item, ItemPostDTO>()
                        .ReverseMap();
        }
        
    }
}

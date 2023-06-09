﻿using FantasyRolAPI.Data;
using FantasyRolAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FantasyRolAPI.DTOs.RaceDTos
{
    public class Race : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Bonus> Bonuses { get; set; }
        public Ability? Ability { get; set; }
        public string? AgeInterval { get; set; }
        public string? Weight { get; set; }
        public string? Height { get; set; }
        public string? DescAlignment { get; set; }
    }
}

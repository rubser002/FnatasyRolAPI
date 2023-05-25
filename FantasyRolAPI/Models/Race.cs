﻿namespace FantasyRolAPI.Models
{
    public class Race
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Bonus>? bonus { get; set; }
        public Ability? Ability { get; set; }

        public string? AgeInterval { get; set; }
        public string? Weight { get; set; }
        public string? Height { get; set; }
        public string? Descalignment { get; set; }

    }
}
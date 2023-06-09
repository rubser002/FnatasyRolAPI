﻿using FantasyRolAPI.Data;

namespace FantasyRolAPI.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? EmailConfirmed { get; set; }

        public List<Character>? Characters { get; set; }

    }
}

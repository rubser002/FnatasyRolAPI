﻿namespace FantasyRolAPI.DTOs
{
    public class UserMiniDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool? EmailConfirmed { get; set; }
    }
}

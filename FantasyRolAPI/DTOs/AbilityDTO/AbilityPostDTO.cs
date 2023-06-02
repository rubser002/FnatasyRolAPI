using FantasyRolAPI.Models;

namespace FantasyRolAPI.DTOs.AbilityDTO
{
    public class AbilityPostDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Level { get; set; }

        public List<Bonus>? Bonuses { get; set; }
        public string? Identifier { get; set; }
    }
}

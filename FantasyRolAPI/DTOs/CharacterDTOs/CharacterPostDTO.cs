using FantasyRolAPI.DTOs.AbilityDTO;
using FantasyRolAPI.Enums;
using FantasyRolAPI.Models;

namespace FantasyRolAPI.DTOs.CharacterDTOs
{
    public class CharacterPostDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Story { get; set; }
        public int Level { get; set; }
        public int? ExperiencePoints { get; set; }
        public Alignment_Type Alignment { get; set; }
        public int? CurrentHitPoints { get; set; }
        public string? CurrentSpellSlots { get; set; }
        public Guid UserId { get; set; }
        public Guid CharacterRaceId { get; set; }
        public Guid CharacterClassId { get; set; }
        public Guid? SubclassId { get; set; }
        public Background? Background { get; set; }
        public List<Bonus>? Bonuses { get; set; }
        

    }
}

using FantasyRolAPI.DTOs.BonusDTOs;
using FantasyRolAPI.Enums;
using FantasyRolAPI.Models;

namespace FantasyRolAPI.DTOs.CharacterDTOs
{
    public class CharacterMiniDTO
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ClassName { get; set; }
        public string? RaceName { get; set; }

        public Guid? CharacterClassId { get; set; }
        public string? Story { get; set; }
        public int Level { get; set; }
        public int? ExperiencePoints { get; set; }
        public Alignment_Type Alignment { get; set; }
        public string AlignmentDescription { get; set; }
        public int? CurrentHitPoints { get; set; }
        public string? CurrentSpellSlots { get; set; }
        public List<BonusMiniDTO> Bonuses { get; set; }
        public Background Background { get; set; }

    }
}

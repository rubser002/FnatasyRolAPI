using FantasyRolAPI.DTOs.AbilityDTO;
using FantasyRolAPI.DTOs.BonusDTOs;
using FantasyRolAPI.Enums;
using FantasyRolAPI.Models;

namespace FantasyRolAPI.DTOs.CharacterDTOs
{
    public class CharacterDetailsMiniDTO
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ClassName { get; set; }
        public Guid? CharacterClassId { get; set; }
        public string? Story { get; set; }
        public int Level { get; set; }
        public int? ExperiencePoints { get; set; }
        public Alignment_Type Alignment { get; set; }
        public Race CharacterRace { get; set; }
        public Class CharacterClass { get; set; }
        public List<Item> Inventory { get; set; }
        public List<AbilityMiniDTO> AbilitiesMini { get; set; }
        public List<Spell> Spells { get; set; }
        public string AlignmentDescription { get; set; }
        public int? CurrentHitPoints { get; set; }
        public string? CurrentSpellSlots { get; set; }
        public List<BonusMiniDTO> Bonuses { get; set; }
        public Background Background { get; set; }


    }
}

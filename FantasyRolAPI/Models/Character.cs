using FantasyRolAPI.Data;
using FantasyRolAPI.Enums;
using System.ComponentModel.DataAnnotations.Schema;


namespace FantasyRolAPI.Models
{
    public class Character : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Story { get; set; }
        public int Level { get; set; }
        public int? ExperiencePoints { get; set; }
        public Alignment_Type Alignment { get; set; }
        public int? CurrentHitPoints { get; set; }
        public string? CurrentSpellSlots { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        [ForeignKey("Race")]
        public Guid CharacterRaceId { get; set; }

        [ForeignKey("Class")]
        public Guid CharacterClassId { get; set; }

        [ForeignKey("Subclass")]
        public Guid? SubclassId { get; set; }
        
        [ForeignKey("Background")]
        public Guid? BackgroundId { get; set; }

        public List<Item> Inventory { get; set; }
        public List<CharacterAbility> CharacterAbilities { get; set; }
        public List<Spell> Spells { get; set; }
        public List<Bonus> Bonuses { get; set; }
        public virtual Race CharacterRace { get; set; }
        public virtual Class CharacterClass { get; set; }
        public virtual Subclass CharacterSubclass { get; set; }
        public virtual User User { get; set; }
        public virtual Background Background { get; set; }
    }
}

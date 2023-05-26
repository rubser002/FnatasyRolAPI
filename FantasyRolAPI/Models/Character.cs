using FantasyRolAPI.Data;
using FantasyRolAPI.Enums;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Security.Claims;

namespace FantasyRolAPI.Models
{
    public class Character : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Story { get; set; }

        public int Level { get; set; }
        public int? ExperiencePoints { get; set; }

        public int CharacterRaceId { get; set; } 
        public int CharacterClassId { get; set; } 
        public int? AlignmentId { get; set; } 
        public int? SubclassId { get; set; } 

        public int CurrentHitPoints { get; set; }
        public string CurrentSpellSlots { get; set; }

        public List<Item> Inventory { get; set; }
        public List<Ability> Abilities { get; set; }
        public List<Spell> Spells { get; set; }

        public Race CharacterRace { get; set; }
        public Class CharacterClass { get; set; }
        public Alignment_Type Alignment { get; set; }
        public Subclass Subclass { get; set; }
    }
}

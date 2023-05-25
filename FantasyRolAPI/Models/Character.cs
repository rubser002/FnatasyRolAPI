using FantasyRolAPI.Enums;
using System.Diagnostics;
using System.Security.Claims;

namespace FantasyRolAPI.Models
{
    public class Character
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Level { get; set; }
        public int ExperiencePoints { get; set; }
        public Race CharacterRace { get; set; }
        public Class CharacterClass { get; set; }
        public Alignment_Type Alignment { get; set; }
        public Subclass Subclass { get; set; }


        public List<Item> Inventory { get; set; }
        public List<Ability> Abilities { get; set; }
        public List<Spell> Spells { get; set; }
        
    }
}

using FantasyRolAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace FantasyRolAPI.Models
{
    public class Ability : BaseEntity
    {
        [StringLength(20)]
        public string Name { get; set; }
        
        public string Description { get; set; }
        public int? Level { get; set; }
        public List<Bonus>? Bonuses { get; set; }
        [StringLength(200)]
        public string? Identifier { get; set; }

        public virtual List<CharacterAbility> CharacterAbilities { get; set; }
        public virtual List<ClassAbility> ClassAbilities { get; set; }
    }
}

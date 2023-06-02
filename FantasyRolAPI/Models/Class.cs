using FantasyRolAPI.Data;
using FantasyRolAPI.Enums;

namespace FantasyRolAPI.Models
{
    public class Class : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dice_Type HitDice { get; set; }

        public List<ClassAbility> ClassAbilities { get; set; }
        public virtual List<Character> Characters { get; set; }
    }
}

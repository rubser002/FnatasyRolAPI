using FantasyRolAPI.Data;
using FantasyRolAPI.Enums;

namespace FantasyRolAPI.Models
{
    public class Bonus : BaseEntity
    {
        public int? bonusValue { get; set; }
        public ProficiencyBonus_Type? setProficiency { get; set; }
        public Characteristics_Type characteristic { get; set; }
    }
}

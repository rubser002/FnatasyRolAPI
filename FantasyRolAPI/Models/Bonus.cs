using FantasyRolAPI.Enums;

namespace FantasyRolAPI.Models
{
    public class Bonus
    {
        public Guid Id { get; set; }
        public int? bonusValue { get; set; }
        public ProficiencyBonus_Type? setProficiency { get; set; }
        public Characteristics_Type characteristic { get; set; }
    }
}

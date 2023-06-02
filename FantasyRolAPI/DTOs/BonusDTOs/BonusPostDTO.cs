using FantasyRolAPI.Enums;

namespace FantasyRolAPI.DTOs.BonusDTOs
{
    public class BonusPostDTO
    {
        public Guid Id { get; set; }
        public int? bonusValue { get; set; }
        public ProficiencyBonus_Type? setProficiency { get; set; }
        public Characteristics_Type characteristic { get; set; }
    }
}

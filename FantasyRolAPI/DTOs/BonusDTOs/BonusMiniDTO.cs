using FantasyRolAPI.Enums;

namespace FantasyRolAPI.DTOs.BonusDTOs
{
    public class BonusMiniDTO
    {
        public int? bonusValue { get; set; }
        public string characteristicDesc { get; set; }
        public ProficiencyBonus_Type? setProficiency { get; set; }
        public Characteristics_Type characteristic { get; set; }
    }
}

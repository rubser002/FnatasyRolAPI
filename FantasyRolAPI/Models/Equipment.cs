using FantasyRolAPI.Enums;

namespace FantasyRolAPI.Models
{
    public class Equipment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Dice_Type? DiceType { get; set; }
        public Characteristics_Type? Modifier { get; set; }
        public int? ArmoClass { get; set; }
        public int? MinChracteristic { get; set; }
    }
}

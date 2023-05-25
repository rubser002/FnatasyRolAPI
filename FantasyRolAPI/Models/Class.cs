using FantasyRolAPI.Enums;

namespace FantasyRolAPI.Models
{
    public class Class
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Dice_Type HitDice { get; set; }
        public List<Ability> ClassAbilities { get; set; }
    }
}

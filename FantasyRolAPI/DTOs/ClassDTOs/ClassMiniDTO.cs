using FantasyRolAPI.Enums;
using FantasyRolAPI.Models;

namespace FantasyRolAPI.DTOs.ClassDTOs
{
    public class ClassMiniDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Dice_Type HitDice { get; set; }

        //public List<ClassAbility> ClassAbilities { get; set; }
    }
}

using FantasyRolAPI.Data;
using FantasyRolAPI.Enums;

namespace FantasyRolAPI.Models
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }

    }

    public class Weapon : Item
    {
        public Dice_Type Damage { get; set; }
        public int Range { get; set; }
        public List<Weapon_Type> WeaponTypes { get; set; }

    }

    public class Armor : Item
    {
        public int ArmorClass { get; set; }
        public Armor_Type ArmorType { get; set; }


    }
}

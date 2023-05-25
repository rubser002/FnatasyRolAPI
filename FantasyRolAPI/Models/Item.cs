using FantasyRolAPI.Enums;

namespace FantasyRolAPI.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }

       
    }

    public class Weapon : Item
    {
        public int Damage { get; set; }
        public int Range { get; set; }
        public WeaponType Type { get; set; }
    }

    public class Armor : Item
    {
        public int ArmorClass { get; set; }
        public ArmorType Type { get; set; }
        // Add more properties specific to an armor
    }
}

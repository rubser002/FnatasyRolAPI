using FantasyRolAPI.Data;

namespace FantasyRolAPI.Models
{
    public class Ability : BaseEntity
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public int? Level { get; set; }
        public List<Bonus>? Bonuses { get; set; }
        public string Identifier { get; set; }
    }
}

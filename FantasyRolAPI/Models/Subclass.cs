using FantasyRolAPI.Data;

namespace FantasyRolAPI.Models
{
    public class Subclass : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Ability> SubClassAbilities { get; set; }

    }
}

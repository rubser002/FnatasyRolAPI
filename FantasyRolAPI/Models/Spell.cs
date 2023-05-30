using FantasyRolAPI.Data;
using FantasyRolAPI.Enums;

namespace FantasyRolAPI.Models
{
    public class Spell : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public School_Type? School { get; set; }
        public int SpellLevel { get; set; }
        public string? Components { get; set; }
        public string? SComponents { get; set; }

    }
}

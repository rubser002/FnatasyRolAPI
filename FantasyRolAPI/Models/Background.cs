using FantasyRolAPI.Data;

namespace FantasyRolAPI.Models
{
    public class Background : BaseEntity
    {
        public string Name { get; set; }
        public string Languages { get; set; }
        public string Features { get; set; }
        public string PersonalityTrait { get; set; }
        public string Ideal { get; set; }
        public string Bond { get; set; }
        public string Flaw { get; set; }
    }
}

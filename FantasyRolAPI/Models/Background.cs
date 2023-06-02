using FantasyRolAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace FantasyRolAPI.Models
{
    public class Background : BaseEntity
    {
        [StringLength(20)]

        public string Name { get; set; }
        [StringLength(200)]

        public string? Languages { get; set; }
        [StringLength(200)]

        public string? Features { get; set; }
        [StringLength(200)]

        public string? PersonalityTrait { get; set; }
        [StringLength(200)]

        public string? Ideal { get; set; }
        [StringLength(200)]

        public string? Bond { get; set; }
        [StringLength(200)]

        public string? Flaw { get; set; }
    }
}

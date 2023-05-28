using FantasyRolAPI.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyRolAPI.Models
{
    public class ClassAbility : BaseEntity
    {
        
        public Guid ClassId { get; set; }
        public Guid AbilityId { get; set; }

        [ForeignKey("ClassId")]
        public Class Class { get; set; }

        [ForeignKey("AbilityId")]
        public Ability Ability { get; set; }
    }
}

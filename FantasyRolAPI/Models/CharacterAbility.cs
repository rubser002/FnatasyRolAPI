using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FantasyRolAPI.Models
{
    public class CharacterAbility
    {
        [Key]
        public Guid CharacterId { get; set; }
        public Character Character { get; set; }

        public Guid AbilityId { get; set; }
        public Ability Ability { get; set; }
    }
}

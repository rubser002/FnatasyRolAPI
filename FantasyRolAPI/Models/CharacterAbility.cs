using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FantasyRolAPI.Data;

namespace FantasyRolAPI.Models
{
    public class CharacterAbility: BaseEntity
    {
        
        public Guid CharacterId { get; set; }
        [ForeignKey("CharacterId")]

        public Character Character { get; set; }

        public Guid AbilityId { get; set; }
        [ForeignKey("AbilityId")]

        public Ability Ability { get; set; }
    }
}

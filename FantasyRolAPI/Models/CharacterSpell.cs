using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FantasyRolAPI.Data;

namespace FantasyRolAPI.Models
{
    public class CharacterSpell : BaseEntity
    {
        
        public Guid CharacterId { get; set; }

        [ForeignKey("CharacterId")]
        public Character Character { get; set; }

        public Guid SpellId { get; set; }

        [ForeignKey("SpellId")]
        public Spell Spell { get; set; }
    }
}

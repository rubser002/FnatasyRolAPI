using System.ComponentModel.DataAnnotations;

namespace FantasyRolAPI.Models
{
    public class CharacterItem
    {
        [Key]
        public Guid CharacterId { get; set; }
        public Character Character { get; set; }

        public Guid ItemId { get; set; }
        public Item Item { get; set; }
    }
}

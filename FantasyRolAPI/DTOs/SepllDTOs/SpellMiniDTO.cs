using FantasyRolAPI.Enums;

namespace FantasyRolAPI.DTOs.SepllDTOs
{
    public class SpellMiniDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? SchoolDesc { get; set; }
        public int SpellLevel { get; set; }
        public string? Components { get; set; }
        public string? SComponents { get; set; }
    }
}

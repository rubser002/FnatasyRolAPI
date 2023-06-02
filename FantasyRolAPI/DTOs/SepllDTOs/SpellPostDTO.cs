using FantasyRolAPI.Enums;

namespace FantasyRolAPI.DTOs.SepllDTOs
{
    public class SpellPostDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public School_Type? School { get; set; }
        public int SpellLevel { get; set; }
        public string? Components { get; set; }
        public string? SComponents { get; set; }
    }
}

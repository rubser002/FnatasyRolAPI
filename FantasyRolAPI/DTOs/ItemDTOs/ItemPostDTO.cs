namespace FantasyRolAPI.DTOs.ItemDTOs
{
    public class ItemPostDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? Weight { get; set; }
        public int? Value { get; set; }
    }
}

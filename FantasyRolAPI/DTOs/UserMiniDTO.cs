namespace FantasyRolAPI.DTOs
{
    public class UserMiniDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? EmailConfirmed { get; set; }
    }
}

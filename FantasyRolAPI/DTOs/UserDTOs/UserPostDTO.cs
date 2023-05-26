namespace FantasyRolAPI.DTOs.UserDTOs
{
    public class UserPostDTO
    {
        public Guid? Id {get;set;}
        public string? Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? EmailConfirmed { get; set; }

    }
}

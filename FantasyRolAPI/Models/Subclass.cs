namespace FantasyRolAPI.Models
{
    public class Subclass
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Ability> SubClassAbilities { get; set; }

    }
}

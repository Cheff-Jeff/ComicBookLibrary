namespace ComicsBackend.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; } = string.Empty;
        public ICollection<Hero> heroes = new List<Hero>();
    }
}

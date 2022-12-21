namespace ComicsBackend.Models
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Team> teams { get; set; } = new List<Team>();
    }
}

using ComicsBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace ComicsBackend.Data
{
    public class ComicDbContext : DbContext
    {
        public ComicDbContext(DbContextOptions<ComicDbContext> options) : base(options) 
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comic>()
                .HasOne(a => a.Artist)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Comic>()
                .HasOne(c => c.CoverArtist)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Seed();
        }

        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Comic> Comics { get; set; }
        public DbSet<Library> libraries { get; set; }
    }
}

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
            modelBuilder.Entity<Hero>()
                .HasMany(t => t.teams)
                .WithMany(h => h.heroes);
            modelBuilder.Entity<Team>()
                .HasMany(h => h.heroes)
                .WithMany(t => t.teams);
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
        public DbSet<Team> Teams { get; set; }
        public DbSet<Hero> Heroes { get; set; }

        //Add-Migration Name -o folder/folder
        //Update-Database
    }
}

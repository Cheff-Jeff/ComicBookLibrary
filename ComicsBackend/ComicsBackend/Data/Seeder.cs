using ComicsBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace ComicsBackend.Data
{
    public static class Seeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .HasData(
                    new Artist { Id = 1, Name = "Steve Ditko" },
                    new Artist { Id = 2, Name = "Jack Kirby" },
                    new Artist { Id = 3, Name = "Bob Kane" });
            modelBuilder.Entity<Writer>()
                .HasData(
                    new Writer { Id = 1, Name = "Stan Lee" },
                    new Writer { Id = 2, Name = "Neil Gaiman" },
                    new Writer { Id = 3, Name = "Dan Slott" });
            modelBuilder.Entity<Publisher>()
                .HasData(
                    new Publisher { Id = 1, Name = "Marvel Comics" },
                    new Publisher { Id = 2, Name = "DC Comics" },
                    new Publisher { Id = 3, Name = "Dark Horse Comics" });
            modelBuilder.Entity<Comic>()
                .HasData(
                    new Comic
                    {
                        Id = 1,
                        Title = "Spider-man #1",
                        Description = "Bla Bla Bla",
                        Image = "Cover.jpg",
                        PublisherId = 1,
                        CoverArtistId = 2,
                        WriterId = 1,
                        ArtistId = 2,
                    },
                    new Comic
                    {
                        Id = 2,
                        Title = "Santman #1",
                        Description = "Bla Bla Bla",
                        Image = "Cover.jpg",
                        PublisherId = 2,
                        CoverArtistId = 3,
                        WriterId = 2,
                        ArtistId = 3,
                    },
                    new Comic
                    {
                        Id = 3,
                        Title = "Walking Dead #1",
                        Description = "Bla Bla Bla",
                        Image = "Cover.jpg",
                        PublisherId = 3,
                        CoverArtistId = 3,
                        WriterId = 3,
                        ArtistId = 1,
                    });
        }
    }
}

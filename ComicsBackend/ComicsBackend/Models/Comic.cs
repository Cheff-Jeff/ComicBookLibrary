using System.ComponentModel.DataAnnotations;

namespace ComicsBackend.Models
{
    public class Comic
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public int CoverArtistId { get; set; }
        public Artist CoverArtist { get; set; }

        public int WriterId { get; set; }
        public Writer Writer { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}

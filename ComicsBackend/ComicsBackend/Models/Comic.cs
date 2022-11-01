using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public string UploadImageAsync() 
        {
            string path = "";
            try
            {
                path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "Resources"));
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (var fileStream = new FileStream(Path.Combine(path, this.ImageFile.FileName), FileMode.Create))
                {
                    this.ImageFile.CopyToAsync(fileStream);
                }
                return path;
            }
            catch (Exception ex)
            {
                throw new Exception("file copy failed", ex);
            }
        }
    }
}

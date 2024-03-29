﻿using Microsoft.Extensions.FileProviders;
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

        public int Popularity { get; set; } = 0;

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public int CoverArtistId { get; set; }
        public Artist CoverArtist { get; set; }

        public int WriterId { get; set; }
        public Writer Writer { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; } = null;

        public async Task<string> UploadImageAsync() 
        {
            string path = "";
            try
            {
                path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "Resources"));
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var fileName = Path.GetFileName(this.ImageFile.FileName);
                var fileExtension = Path.GetExtension(fileName);
                var uniqueFileName = Convert.ToString(Guid.NewGuid());
                var newFileName = String.Concat(uniqueFileName, fileExtension);

                using (var fileStream = new FileStream(Path.Combine(path, newFileName), FileMode.Create))
                {
                    await this.ImageFile.CopyToAsync(fileStream);
                    this.Image = newFileName;
                }
                return newFileName;
            }
            catch (Exception ex)
            {
                throw new Exception("file copy failed", ex);
            }
        }
    }
}

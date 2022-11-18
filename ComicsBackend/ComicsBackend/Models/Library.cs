using System.ComponentModel.DataAnnotations;

namespace ComicsBackend.Models
{
    public class Library
    {
        public int Id { get; set; }
        
        [Required]
        public Comic comic { get; set; }
        
        [Required]
        public int UserId { get; set; }
    }
}

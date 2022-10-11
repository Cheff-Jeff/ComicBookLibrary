using System.ComponentModel.DataAnnotations;

namespace ComicsBackend.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
    }
}

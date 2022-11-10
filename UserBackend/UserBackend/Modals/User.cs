using System.ComponentModel.DataAnnotations;

namespace UserBackend.Modals
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Email { get; set; }

        [Required]
        [MinLength(10)]
        public string Password { get; set; }

        public string Salt { get; set; }

        public void encrypt() 
        {
            EncryptionHandler handler = new EncryptionHandler();
            byte[] salt = handler.AddSalt();
            this.Salt = Convert.ToBase64String(salt);
            this.Password = handler.hash(this.Password, salt);
        }

        public void keepOldInfo(string salt, string pass)
        { 
            this.Salt = salt;
            this.Password = pass;
        }
    }
}

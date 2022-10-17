using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Data.Entities
{
    public class Users
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(256)]
        public string Username { get; set; }
        [MaxLength(256)]
        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kamo_learnhub.Models
{
    public class User
    {
        [Key]
        public int User_ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public bool IsActive { get; set; } = true;

        // 🔑 Foreign Key
        public int UserRole_ID { get; set; }

        [ForeignKey(nameof(UserRole_ID))]
        public UserRole UserRole { get; set; }

        // Navigation
        public StudentProfile StudentProfile { get; set; }
    }
}

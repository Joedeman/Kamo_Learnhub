using System.ComponentModel.DataAnnotations;

namespace kamo_learnhub.Models
{
    public class UserRole
    {
        [Key]
        public int UserRole_ID { get; set; }

        [Required]
        public string RoleName { get; set; }

        // Navigation
        public ICollection<User> Users { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kamo_learnhub.Models
{
    public class StudentProfile
    {
        [Key, ForeignKey("User")]
        public int Student_ID { get; set; }

        public string Grade { get; set; }

        public string Curriculum { get; set; }

        // Navigation
        public User User { get; set; }
        public ICollection<StudentVideo> StudentVideos { get; set; }
    }
}

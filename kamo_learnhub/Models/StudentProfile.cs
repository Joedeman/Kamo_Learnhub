using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kamo_learnhub.Models
{
  public class StudentProfile
  {
    [Key]
    public int Student_ID { get; set; }   // PK

    [Required]
    public int User_ID { get; set; }       // FK → User.User_ID

    public string Grade { get; set; }
    public string Curriculum { get; set; }


    public bool IsActive { get; set; } = true;

    // Navigation
    [ForeignKey(nameof(User_ID))]
    public User User { get; set; }

    public ICollection<StudentVideo> StudentVideos { get; set; }
  }
}

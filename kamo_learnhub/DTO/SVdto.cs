using kamo_learnhub.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace kamo_learnhub.DTO
{
  public class SVdto
  {
    [Key]
    public int StudentVideo_ID { get; set; }

    public int Student_ID { get; set; }
    public int Video_ID { get; set; }

    public bool IsCompleted { get; set; }
    public DateTime AssignedAt { get; set; } = DateTime.Now;

    // Navigation
    [ForeignKey(nameof(Student_ID))]
    public StudentProfile StudentProfile { get; set; }

    [ForeignKey(nameof(Video_ID))]
    public Video Video { get; set; }
  }
}

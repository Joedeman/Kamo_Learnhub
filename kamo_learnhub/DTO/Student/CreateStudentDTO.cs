using kamo_learnhub.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace kamo_learnhub.DTO.Student
{
  public class CreateStudentDTO
  {

    public int User_ID { get; set; }   // FK to User
    public string Grade { get; set; }
    public string Curriculum { get; set; }
    public bool IsActive { get; set; }

  }
}

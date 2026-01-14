namespace kamo_learnhub.DTO.Student
{
  public class ReadStudentDTO
  {
    public int Student_ID { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Grade { get; set; }
    public string Curriculum { get; set; }
    public bool IsActive
    {
      get; set; }
    }
}

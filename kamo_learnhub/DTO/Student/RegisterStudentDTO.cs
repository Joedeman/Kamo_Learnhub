namespace kamo_learnhub.DTO.Student
{
  public class RegisterStudentDTO
  {

    //user info

    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }

    //student info

    public string Curriculum { get; set; }
    public string Grade { get; set; }

  }
}

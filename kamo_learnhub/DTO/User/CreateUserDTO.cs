namespace kamo_learnhub.DTO.User
{
  public class CreateUserDTO
  {
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public int UserRole_ID { get; set; }
  }
}

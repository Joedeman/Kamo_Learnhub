namespace kamo_learnhub.DTO.User
{
  public class UserResponseDTO
  {

    public int User_ID { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public bool IsActive { get; set; }
  }
}

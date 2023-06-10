namespace CantinaUPT_API.Web.ApiModels;

public class RegisterRequestDTO
{
  public string Username { get; set; }
  public string Email { get; set; }
  public string? Password { get; set; }  
  public int RoleId { get; set; }
  public int CanteenId { get; set; }
}

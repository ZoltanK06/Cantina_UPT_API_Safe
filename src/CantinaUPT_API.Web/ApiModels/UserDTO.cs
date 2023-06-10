namespace CantinaUPT_API.Web.ApiModels;

public class UserDTO
{
  public int Id { get; set; }
  public string Username { get; set; }
  public string Email { get; set; }
  public CanteenNameDTO Canteen { get; set; }
}

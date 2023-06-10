namespace CantinaUPT_API.Web.ApiModels;

public class OrderedMealDTO
{
  public int Id { get; set; }
  public string? Name { get; set; } 
  public double? Price { get; set; }
  public string? PictureURL { get; set; }
}

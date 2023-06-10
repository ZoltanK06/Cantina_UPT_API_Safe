using CantinaUPT_API.Core.ProjectAggregate;

namespace CantinaUPT_API.Web.ApiModels;

public class MealDTO
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public double Price { get; set; }
  public string PictureURL { get; set; }
  public bool Disponibility { get; set; }
  public int CanteenId { get; set; }

  public int PortionId { get; set; }
  public int CategoryId { get; set; }
}

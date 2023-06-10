using CantinaUPT_API.Core.ProjectAggregate;

namespace CantinaUPT_API.Web.ApiModels;

public class MealResponseDTO
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public double Price { get; set; }
  public string PictureURL { get; set; }
  public bool Disponibility { get; set; }

  public string Portion { get; set; }
  public string Category { get; set; }
}

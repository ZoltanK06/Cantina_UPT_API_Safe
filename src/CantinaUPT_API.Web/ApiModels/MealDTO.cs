using CantinaUPT_API.Core.ProjectAggregate;

namespace CantinaUPT_API.Web.ApiModels;

public class MealDTO
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public double Price { get; set; }

  public Portion Portion { get; set; }
  public Category Category { get; set; }
}

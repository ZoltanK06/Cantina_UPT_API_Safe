using CantinaUPT_API.Core.ProjectAggregate;

namespace CantinaUPT_API.Web.ApiModels;

public class CanteenWithMealsByCategoryDTO
{
  public List<MealResponseDTO> mealList { get; set; }
  public CanteenWithMealsByCategoryDTO(List<Meal> meals)
  {
    mealList = new List<MealResponseDTO>();
    meals.ForEach(e =>
    {
      var mealResponseDTO = new MealResponseDTO
      {
        Id = e.Id,
        Name = e.Name,
        Description = e.Description,
        Price = e.Price,
        PictureURL = e.PictureURL,
        Disponibility = e.Disponibility,
        Portion = e.Portion.PortionName,
        Category = e.Category.CategoryName,
      };
      mealList.Add(mealResponseDTO);
    });
  }
}

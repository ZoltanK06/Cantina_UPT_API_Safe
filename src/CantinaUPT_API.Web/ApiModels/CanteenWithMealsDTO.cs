using AutoMapper;
using CantinaUPT_API.Core.ProjectAggregate;

namespace CantinaUPT_API.Web.ApiModels;

public class CanteenWithMealsDTO
{
  public List<FoodsCategorized> foodsCategorized = new List<FoodsCategorized>();
  public CanteenWithMealsDTO(List<Meal> meals)
  {

    var categories = meals.Select(meal => meal.Category).Distinct();

    foreach(Category category in categories)
    {
      var mealsOfCategory = meals.Where(meal => meal.Category == category);
      FoodsCategorized newFoodsCategorized = new FoodsCategorized { title = category.ToString(), data = mealsOfCategory.ToList() };
      foodsCategorized.Add(newFoodsCategorized);
    }
  }
}

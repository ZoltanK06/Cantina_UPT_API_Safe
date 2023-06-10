using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace CantinaUPT_API.Core.ProjectAggregate.Specifications;
public class MealsWithCategoryAndPortion: Specification<Meal>
{
  public MealsWithCategoryAndPortion(List<int> mealIds)
  {
    Query.Where(meal => mealIds.Contains(meal.Id)).Include(meal => meal.Portion).Include(meal => meal.Category);
  }
}

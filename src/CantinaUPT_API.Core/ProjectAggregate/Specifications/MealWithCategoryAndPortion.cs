using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace CantinaUPT_API.Core.ProjectAggregate.Specifications;
public class MealWithCategoryAndPortion: Specification<Meal>, ISingleResultSpecification
{
  public MealWithCategoryAndPortion(int mealId)
  {
    Query.Where(meal => meal.Id == mealId).Include(meal => meal.Category).Include(meal => meal.Portion);
  }
}

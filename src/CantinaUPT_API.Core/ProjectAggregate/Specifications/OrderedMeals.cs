using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace CantinaUPT_API.Core.ProjectAggregate.Specifications;
public class OrderedMeals: Specification<Meal>
{
  public OrderedMeals(List<int> mealIds)
  {
    Query.Where(meal => mealIds.Contains(meal.Id));
  }
}

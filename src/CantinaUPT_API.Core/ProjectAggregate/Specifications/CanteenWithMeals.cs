using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace CantinaUPT_API.Core.ProjectAggregate.Specifications;
public class CanteenWithMeals : Specification<Canteen>, ISingleResultSpecification
{
  public CanteenWithMeals(int canteenId)
  {
    Query.Where(canteen => canteen.Id == canteenId).Include(canteen => canteen.Meals);
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace CantinaUPT_API.Core.ProjectAggregate.Specifications;
public class CanteenWithMenus : Specification<Canteen>, ISingleResultSpecification
{
  public CanteenWithMenus(int canteenId)
  {
    Query.Where(canteen => canteen.Id == canteenId).Include(canteen => canteen.Menus);
  }
}


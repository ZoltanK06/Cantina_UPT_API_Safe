using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace CantinaUPT_API.Core.ProjectAggregate.Specifications;
public class FilterManagers: Specification<User>
{
  public FilterManagers()
  {
    Query.Where(user => user.Role.Id == 3).Include(user => user.Canteen);
  }
}

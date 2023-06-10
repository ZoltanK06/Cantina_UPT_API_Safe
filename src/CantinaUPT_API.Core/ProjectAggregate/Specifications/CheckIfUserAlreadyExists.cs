using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace CantinaUPT_API.Core.ProjectAggregate.Specifications;
public class CheckIfUserAlreadyExists: Specification<User>, ISingleResultSpecification
{
  public CheckIfUserAlreadyExists(User user)
  {
    Query.Where(x => x.Username == user.Username || x.Email == user.Email).Include(user => user.Role).Include(user => user.Canteen);
  }
}

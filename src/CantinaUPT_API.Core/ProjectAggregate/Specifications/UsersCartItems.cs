using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace CantinaUPT_API.Core.ProjectAggregate.Specifications;
public class UsersCartItems : Specification<CartItem>, ISingleResultSpecification
{
  public UsersCartItems(int userId)
  {
    Query.Where(item => item.UserId == userId).Include(item => item.Meal);
  }
}

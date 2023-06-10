using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace CantinaUPT_API.Core.ProjectAggregate.Specifications;
public class UserWithCards: Specification<User>, ISingleResultSpecification
{
  public UserWithCards(int userId)
  {
    Query.Where(user => user.Id == userId).Include(user => user.Cards);
  }
}

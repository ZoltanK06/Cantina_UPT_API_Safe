using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace CantinaUPT_API.Core.ProjectAggregate.Specifications;
public class CheckIfItemIsAlreadyInCart : Specification<OrderItem>, ISingleResultSpecification
{
  public CheckIfItemIsAlreadyInCart(OrderItem cartItem)
  {
    Query.Where(x => x.Meal == cartItem.Meal);
  }
}

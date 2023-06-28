using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace CantinaUPT_API.Core.ProjectAggregate.Specifications;
public class UsersOrder : Specification<Order>, ISingleResultSpecification
{
  public UsersOrder(int userId)
  {
    Query
      .Where(order => order.UserId == userId && order.Status.OrderStatusName != "Taken")
      .Include(order => order.Status)
      .Include(order => order.OrderItems)
      .ThenInclude(orderItem => orderItem.Meal);
  }
}

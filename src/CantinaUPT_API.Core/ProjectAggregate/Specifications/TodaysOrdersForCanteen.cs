using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace CantinaUPT_API.Core.ProjectAggregate.Specifications;
public class TodaysOrdersForCanteen: Specification<Order>
{
  public TodaysOrdersForCanteen(int canteenId)
  {
    Query.Where(order => order.OrderDate.Day == DateTime.Now.Day && order.OrderDate.Month == DateTime.Now.Month && order.OrderDate.Year == DateTime.Now.Year && order.CanteenId == canteenId).Include(order => order.Status).Include(order => order.OrderItems).ThenInclude(orderItem => orderItem.Meal);
  }
}

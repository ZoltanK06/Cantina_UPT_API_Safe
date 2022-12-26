using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CantinaUPT_API.Core.ProjectAggregate;

namespace CantinaUPT_API.Core.Interfaces;
public interface IOrderService
{
  Task<Order> GetUsersOrder(int userId);
  Task<bool> AddOrder(Order order);
  Task DeleteOrder(int orderId);
  Task UpdateOrderStatus(int oldOrderId, OrderStatus newStatus);
  Task UpdateOrder(int oldOrderId, Order newOrder);
}

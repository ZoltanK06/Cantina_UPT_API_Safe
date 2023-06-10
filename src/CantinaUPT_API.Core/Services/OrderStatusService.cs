using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CantinaUPT_API.Core.Interfaces;
using CantinaUPT_API.Core.ProjectAggregate;
using CantinaUPT_API.SharedKernel.Interfaces;

namespace CantinaUPT_API.Core.Services;
public class OrderStatusService: IOrderStatusService
{
  public readonly IReadRepository<OrderStatus> _orderStatusRepo;

  public OrderStatusService(IReadRepository<OrderStatus> orderStatusRepo)
  {
    _orderStatusRepo = orderStatusRepo;
  }

  public async Task<OrderStatus> GetOrderStatusById(int orderStatusId)
  {
    return await _orderStatusRepo.GetByIdAsync(orderStatusId);
  }

  public async Task<List<OrderStatus>> GetAllOrderStatuses()
  {
    return await _orderStatusRepo.ListAsync();
  }
}

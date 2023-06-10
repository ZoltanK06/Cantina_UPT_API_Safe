using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CantinaUPT_API.Core.Interfaces;
using CantinaUPT_API.Core.ProjectAggregate;
using CantinaUPT_API.SharedKernel.Interfaces;

namespace CantinaUPT_API.Core.Services;
public class OrderItemService: IOrderItemService
{
  private readonly IReadRepository<OrderItem> _readRepository;
  private readonly IRepository<OrderItem> _repository;

  public OrderItemService(IRepository<OrderItem> repository, IReadRepository<OrderItem> readRepository)
  {
    _repository = repository;
    _readRepository = readRepository;
  }

  public async Task<List<OrderItem>> AddOrderItems(List<OrderItem> orderItems)
  {
    return (await _repository.AddRangeAsync(orderItems)).ToList();
  }
}

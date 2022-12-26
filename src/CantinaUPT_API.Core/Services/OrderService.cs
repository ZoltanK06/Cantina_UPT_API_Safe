using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CantinaUPT_API.Core.Interfaces;
using CantinaUPT_API.Core.ProjectAggregate;
using CantinaUPT_API.Core.ProjectAggregate.Specifications;
using CantinaUPT_API.SharedKernel.Interfaces;

namespace CantinaUPT_API.Core.Services;
public class OrderService : IOrderService
{
  private readonly IReadRepository<Order> _readRepository;
  private readonly IRepository<Order> _repository;

  public OrderService(IReadRepository<Order> readRepository, IRepository<Order> repository)
  {
    _readRepository = readRepository;
    _repository = repository;
  }
  
  public async Task<Order> GetUsersOrder(int userId)
  {
    var specification = new UsersOrder(userId);

    return await _readRepository.GetBySpecAsync(specification);
  }

  public async Task<bool> AddOrder(Order order)
  {
    var specification = new UsersOrder(order.UserId);

    var existingOrder = await _readRepository.GetBySpecAsync(specification);

    if (existingOrder != null)
    {
      return false;
    }
    else
    {
      await _repository.AddAsync(order);
      await _repository.SaveChangesAsync();
      return true;
    }
  }

  public async Task DeleteOrder(int orderId)
  {
    var order = await _readRepository.GetByIdAsync(orderId);

    if(order != null)
    {
      await _repository.DeleteAsync(order);
      await _repository.SaveChangesAsync();
    }
    else
    {
      throw new Exception();
    }
  }

  public async Task UpdateOrderStatus(int oldOrderId, OrderStatus newStatus)
  {
    var oldOrder = await _readRepository.GetByIdAsync(oldOrderId);

    if(oldOrder != null)
    {
      oldOrder.Status = newStatus;

      await _repository.UpdateAsync(oldOrder);
      await _repository.SaveChangesAsync();
    }
    else
    {
      throw new Exception();
    }
  }

  public async Task UpdateOrder(int oldOrderId, Order newOrder)
  {
    var oldOrder = await _readRepository.GetByIdAsync(oldOrderId);

    if(oldOrder != null)
    {
      oldOrder.OrderDate = newOrder.OrderDate;
      oldOrder.Status = newOrder.Status;
      oldOrder.CartItems = newOrder.CartItems;
      oldOrder.TotalPrice = newOrder.TotalPrice;

      await _repository.UpdateAsync(oldOrder);
      await _repository.SaveChangesAsync();
    }
    else
    {
      throw new Exception();
    }
  }
}

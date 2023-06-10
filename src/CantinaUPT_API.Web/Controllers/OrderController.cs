using AutoMapper;
using CantinaUPT_API.Core.Interfaces;
using CantinaUPT_API.Core.ProjectAggregate;
using CantinaUPT_API.Web.ApiModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CantinaUPT_API.Web.Controllers;

[Route("api/order")]
[ApiController]
public class OrderController : ControllerBase
{
  private readonly IOrderService _orderService;
  private readonly IMapper _mapper;
  private readonly IOrderStatusService _orderStatusService;
  private readonly IMealService _mealService;

  public OrderController(IOrderService orderService, IMapper mapper, IOrderStatusService orderStatusService, IMealService mealService)
  {
    _orderService = orderService;
    _mapper = mapper;
    _orderStatusService = orderStatusService;
    _mealService = mealService;
  }

  [HttpGet]
  [Route("GetCurrentOrder")]
  public async Task<IActionResult> GetCurrentOrder([FromQuery]int userId)
  {
    try
    {
      var todaysOrders = await _orderService.GetTodaysOrders();

      var currentOrder = todaysOrders.Find(x => x.UserId == userId && (x.Status.OrderStatusName == "Preparing" || x.Status.OrderStatusName == "Ready"));

      if(currentOrder == null)
      {
        return Ok();
      }

      var preparingOrdersCount = todaysOrders.Count(x => x.Status.OrderStatusName == "Preparing" && x.Id < currentOrder.Id);

      var currentOrderItems = _mapper.Map<List<OrderItemDTO>>(currentOrder.OrderItems);

      var currentOrderDTO = new OrderDTO
      {
        Id = currentOrder.Id,
        UserId = currentOrder.UserId,
        OrderNumber = todaysOrders.FindIndex(x => x.Id == currentOrder.Id) + 1,
        OrderDate = currentOrder.OrderDate,
        Status = currentOrder.Status.OrderStatusName,
        TotalPrice = currentOrder.TotalPrice,
        PrepareTime = (preparingOrdersCount + 1) * 10,
        OrderItemsDTO = currentOrderItems
      };

      return Ok(currentOrderDTO);
    }
    catch(Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpGet]
  [Route("GetOrdersForCanteen")]
  [Authorize(Roles = "Manager")]
  public async Task<IActionResult> GetOrdersForCanteen([FromQuery] int canteenId)
  {
    try
    {
      var todaysOrders = await _orderService.GetTodaysOrdersForCanteen(canteenId);

      if (todaysOrders.Any())
      {
        List<OrderDTO> orders = new List<OrderDTO>();

        todaysOrders.ForEach(order =>
        {
          var orderItems = _mapper.Map<List<OrderItemDTO>>(order.OrderItems);
          var newOrder = _mapper.Map<OrderDTO>(order);
          newOrder.OrderItemsDTO = orderItems;
          newOrder.OrderNumber = todaysOrders.FindIndex(x => x.Id == order.Id) + 1;
          newOrder.Status = order.Status.OrderStatusName;
          orders.Add(newOrder);
        });

        return Ok(orders);

      }
      else
      {
        return Ok();
      }
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpPost]
  [Route("AddOrder")]
  public async Task<IActionResult> AddOrder(OrderDTO newOrderDTO)
  {
    try
    {
      var orderStatus = await _orderStatusService.GetOrderStatusById((int)newOrderDTO.StatusId);
      
      List<int> mealIds = newOrderDTO.OrderItemsDTO.Select(x => x.Meal.Id).ToList();
      var meals = await _mealService.GetOrderedMealsByIds(mealIds);
      
      List<OrderItem> orderItems = new List<OrderItem>();
      foreach (var mealId in mealIds)
      {
        var orderItem = new OrderItem
        {
          Meal = meals.Where(meal => meal.Id == mealId).FirstOrDefault(),
          Quantity = newOrderDTO.OrderItemsDTO.Where(orderItem => orderItem.Meal.Id == mealId).FirstOrDefault().Quantity
        };
        orderItems.Add(orderItem);
      }
      
      var order = new Order
      {
        OrderDate = newOrderDTO.OrderDate,
        Status = orderStatus,
        TotalPrice = newOrderDTO.TotalPrice,
        OrderItems = orderItems,
        UserId = newOrderDTO.UserId,
        CanteenId = newOrderDTO.CanteenId
      };

      await _orderService.AddOrder(order);
      return Ok();
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpDelete]
  [Route("DeleteOrder")]
  [Authorize]
  public async Task<IActionResult> DeleteOrder(int orderId)
  {
    try
    {
      await _orderService.DeleteOrder(orderId);
      return Ok();
    }
    catch(Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpPatch]
  [Route("UpdateOrderStatus")]
  [Authorize(Roles = "Manager")]
  public async Task<IActionResult> UpdateOrderStatus(int orderId, int newOrderStatusId)
  {
    try
    {
      var newOrderStatus = await _orderStatusService.GetOrderStatusById(newOrderStatusId);
      await _orderService.UpdateOrderStatus(orderId, newOrderStatus);
      return Ok();
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }
}

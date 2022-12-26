using AutoMapper;
using CantinaUPT_API.Core.Interfaces;
using CantinaUPT_API.Core.ProjectAggregate;
using CantinaUPT_API.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;

namespace CantinaUPT_API.Web.Controllers;

[Route("api/order")]
[ApiController]
public class OrderController : ControllerBase
{
  private readonly IOrderService _orderService;
  private readonly IMapper _mapper;

  public OrderController(IOrderService orderService, IMapper mapper)
  {
    _orderService = orderService;
    _mapper = mapper;
  }

  [HttpGet]
  [Route("GetCurrentOrder")]
  public async Task<IActionResult> GetCurrentOrder()
  {
    try
    {
      var currentOrder = await _orderService.GetUsersOrder(1);
      var currentOrderDTO = _mapper.Map<OrderDTO>(currentOrder);

      return Ok(currentOrderDTO);
    }
    catch(Exception)
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
      var order = _mapper.Map<Order>(newOrderDTO);
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
  public async Task<IActionResult> UpdateOrderStatus(int orderId, OrderStatus newOrderStatus)
  {
    try
    {
      await _orderService.UpdateOrderStatus(orderId, newOrderStatus);
      return Ok();
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpPut]
  [Route("UpdateOrder")]
  public async Task<IActionResult> UpdateOrder(int orderId, OrderDTO newOrderDTO)
  {
    try
    {
      var newOrder = _mapper.Map<Order>(newOrderDTO);
      await _orderService.UpdateOrder(orderId, newOrder);
      return Ok();
    }
    catch(Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }
}

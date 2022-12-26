using AutoMapper;
using CantinaUPT_API.Core.Interfaces;
using CantinaUPT_API.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;

namespace CantinaUPT_API.Web.Controllers;

[Route("api/cart")]
[ApiController]
public class CartController : ControllerBase
{
  public readonly ICartService _cartService;
  public readonly IMapper _mapper;

  public CartController(ICartService cartService, IMapper mapper)
  {
    _cartService = cartService;
    _mapper = mapper;
  }

  [HttpPost]
  [Route("AddToCart")]
  public async Task<IActionResult> AddToCart([FromBody]int mealId) 
  {
    try
    {
      await _cartService.AddToCart(mealId);
      return Ok();
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
    
  }

  [HttpPut]
  [Route("IncreaseQuantity")]
  public async Task<IActionResult> IncreaseQuantity([FromBody]int cartItemId)
  {
    try
    {
      await _cartService.IncreaseQuantity(cartItemId);
      return Ok();
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpPut]
  [Route("DecreaseQuantityOrDelete")]
  public async Task<IActionResult> DecreaseQuantityOrDelete([FromBody] int cartItemId)
  {
    try
    {
      await _cartService.DecreaseQuantityOrDelete(cartItemId);
      return Ok();
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpGet]
  [Route("GetCartItems")]
  public async Task<IActionResult> GetCartItems()
  {
    try
    {
      var cartItems = await _cartService.GetCartItems();
      var result = _mapper.Map<List<CartItemDTO>>(cartItems);
      return Ok(result);
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpDelete]
  [Route("DeleteCartItems")]
  public async Task<IActionResult> DeleteCartItems()
  {
    try
    {
      await _cartService.DeleteCartItems();
      return Ok();
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

}

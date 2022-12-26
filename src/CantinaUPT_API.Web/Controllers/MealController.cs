using AutoMapper;
using CantinaUPT_API.Core.Interfaces;
using CantinaUPT_API.Core.ProjectAggregate;
using CantinaUPT_API.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;

namespace CantinaUPT_API.Web.Controllers;

[Route("api/meal")]
[ApiController]
public class MealController : ControllerBase
{
  private readonly IMealService _mealService;
  private readonly IMapper _mapper;

  public MealController(IMealService mealService, IMapper mapper)
  {
    _mealService = mealService;
    _mapper = mapper;
  }

  [HttpGet]
  [Route("GetMeal/{id}")]
  public async Task<IActionResult> GetMeal(int id)
  {
    try
    {
      var meal = await _mealService.GetMeal(id);
      var result = _mapper.Map<MealDTO>(meal);
      return Ok(result);
    }
    catch(Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  
  [HttpGet]
  [Route("GetAllMeals")]
  public async Task<IActionResult> GetAllMeals()
  {
    try
    {
      var meals = await _mealService.GetAllMeals();
      var result = _mapper.Map<List<MealDTO>>(meals);
      return Ok(result);
    }
    catch(Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpDelete]
  [Route("DeleteMeal/{id}")]
  public async Task<IActionResult> DeleteMeal(int id)
  {
    try
    {
      await _mealService.DeleteMeal(id);
    }
    catch(Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }

    return StatusCode(StatusCodes.Status200OK);
  }

  [HttpPost]
  [Route("AddMeal")]
  public async Task<IActionResult> AddMeal([FromBody] MealDTO mealdto)
  {
    try
    {
      var meal = _mapper.Map<Meal>(mealdto);
      await _mealService.AddMeal(meal);
    }
    catch(Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
    return StatusCode(StatusCodes.Status200OK);
  }

  [HttpPut]
  [Route("UpdateMeal/{id}")]
  public async Task<IActionResult> UpdateMeal(int id, [FromBody] MealDTO mealdto)
  {
    try
    {
      var meal = _mapper.Map<Meal>(mealdto);
      await _mealService.UpdateMeal(id, meal);
    }
    catch(Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }

    return Ok();

  }
}

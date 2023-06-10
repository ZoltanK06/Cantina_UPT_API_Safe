using AutoMapper;
using CantinaUPT_API.Core.Interfaces;
using CantinaUPT_API.Core.ProjectAggregate;
using CantinaUPT_API.Web.ApiModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CantinaUPT_API.Web.Controllers;

[Route("api/meal")]
[ApiController]
[Authorize(Roles = "Manager")]
public class MealController : ControllerBase
{
  private readonly IMealService _mealService;
  private readonly IMapper _mapper;
  private readonly IPortionService _portionService;
  private readonly ICategoryService _categoryService;
  private readonly ICanteenService _canteenService;

  public MealController(IMealService mealService, IMapper mapper, IPortionService portionService, ICategoryService categoryService, ICanteenService canteenService)
  {
    _mealService = mealService;
    _mapper = mapper;
    _portionService = portionService;
    _categoryService = categoryService;
    _canteenService = canteenService;
  }

  [HttpGet]
  [Route("GetMeal/{id}")]
  public async Task<IActionResult> GetMeal(int id)
  {
    try
    {
      var meal = await _mealService.GetMeal(id);
      var result = _mapper.Map<MealResponseDTO>(meal);

      result.Category = meal.Category.CategoryName;
      result.Portion = meal.Portion.PortionName;

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
      var result = _mapper.Map<List<MealResponseDTO>>(meals);

      for(int i = 0; i < meals.Count(); i++)
      {
        result.ElementAt(i).Category = meals.Find(meal => meal.Id == result.ElementAt(i).Id).Category.CategoryName;
        result.ElementAt(i).Portion = meals.Find(meal => meal.Id == result.ElementAt(i).Id).Portion.PortionName;
      }
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
      var portion = await _portionService.GetPortionById(mealdto.PortionId);
      var category = await _categoryService.GetCategoryById(mealdto.CategoryId);
      var meal = new Meal
      {
        Name = mealdto.Name,
        Description = mealdto.Description,
        Price = mealdto.Price,
        PictureURL = mealdto.PictureURL,
        Portion = portion,
        Category = category
      };
      var addedMeal = await _mealService.AddMeal(meal);
      await _canteenService.AssignMealToCanteen(mealdto.CanteenId, addedMeal);
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
      var portion = await _portionService.GetPortionById(mealdto.PortionId);
      var category = await _categoryService.GetCategoryById(mealdto.CategoryId);
      var meal = new Meal
      {
        Name = mealdto.Name,
        Description = mealdto.Description,
        Price = mealdto.Price,
        PictureURL = mealdto.PictureURL,
        Portion = portion,
        Category = category
      };
      await _mealService.UpdateMeal(id, meal);
    }
    catch(Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }

    return Ok();

  }

  [HttpPut]
  [Route("ChangeDisponibility")]
  public async Task<IActionResult> ChangeDisponibility([FromQuery] int mealId)
  {
    try 
    {
      await _mealService.ChangeDisponibility(mealId);
      return Ok();
    }
    catch(Exception) 
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }
}

using AutoMapper;
using CantinaUPT_API.Core.Interfaces;
using CantinaUPT_API.Core.ProjectAggregate;
using CantinaUPT_API.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;

namespace CantinaUPT_API.Web.Controllers;

[Route("api/canteen")]
[ApiController]
public class CanteenController : ControllerBase
{
  private readonly ICanteenService _canteenService;
  private readonly IMapper _mapper;

  public CanteenController(ICanteenService canteenService, IMapper mapper)
  {
    _canteenService = canteenService;
    _mapper = mapper;
  }

  [HttpGet]
  [Route("GetEveryCanteensDetails")]
  public async Task<IActionResult> GetEveryCanteensDetails()
  {
    try
    {
      var canteens = await _canteenService.GetEveryCanteensDetails();
      var result = _mapper.Map<List<CanteensDetailsDTO>>(canteens);
      return Ok(result);
    }
    catch(Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpGet]
  [Route("GetMealsOfCanteen/{id}")]
  public async Task<IActionResult> GetMealsOfCanteen(int id)
  {
    try
    {
      var canteen = await _canteenService.GetMealsOfCanteen(id);
      var result = new CanteenWithMealsDTO(canteen.Meals);
      return Ok(result);
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpGet]
  [Route("GetMenusOfCanteen/{id}")]
  public async Task<IActionResult> GetMenusOfCanteen(int id)
  {
    try
    {
      var canteen = await _canteenService.GetMenusOfCanteen(id);
      var result = new CanteenWithMenusDTO(canteen.Id, canteen.Menus);
      return Ok(result);
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpPost]
  [Route("AssignMealToCanteen")]
  public async Task<IActionResult> AssignMealToCanteen([FromQuery]int canteenId,[FromBody] MealDTO mealDTO)
  {
    try
    {
      var meal = _mapper.Map<Meal>(mealDTO);
      await _canteenService.AssignMealToCanteen(canteenId, meal);
      return Ok();
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpPost]
  [Route("AssignMealsToCanteen")]
  public async Task<IActionResult> AssignMealsToCanteen([FromQuery] int canteenId, [FromBody] List<MealDTO> mealsDTO)
  {
    try
    {
      var meals = _mapper.Map<List<Meal>>(mealsDTO);
      await _canteenService.AssignMealsToCanteen(canteenId, meals);
      return Ok();
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpPost]
  [Route("AssignMealsByIdToCanteen")]
  public async Task<IActionResult> AssignMealsByIdToCanteen([FromQuery] int canteenId, [FromBody] List<int> mealIds)
  {
    try
    {
      await _canteenService.AssignMealsByIdToCanteen(canteenId, mealIds);
      return Ok();
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }


  [HttpPost]
  [Route("AddCanteen")]
  public async Task<IActionResult> AddCanteen([FromBody]CanteensDetailsDTO canteenDetailsDto)
  {
    try
    {
      var canteen = _mapper.Map<Canteen>(canteenDetailsDto);
      canteen.Menus = new List<DailyMenu>();
      canteen.Meals = new List<Meal>();
      await _canteenService.AddCanteen(canteen);
      return Ok();
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpDelete]
  [Route("DeleteCanteen/{id}")]
  public async Task<IActionResult> DeleteCanteen(int id) 
  {
    try
    {
      await _canteenService.DeleteCanteen(id);
      return Ok();
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpPut]
  [Route("UpdateCanteen/")]
  public async Task<IActionResult> UpdateCanteen(int id, CanteensDetailsDTO canteenDetails)
  {
    try
    {
      var canteen = _mapper.Map<Canteen>(canteenDetails);
      await _canteenService.UpdateCanteenDetails(id, canteen);
      return Ok();
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

}

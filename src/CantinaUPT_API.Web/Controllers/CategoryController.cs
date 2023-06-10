using CantinaUPT_API.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CantinaUPT_API.Web.Controllers;
[Route("api/category")]
[ApiController]

public class CategoryController: ControllerBase
{
  private readonly ICategoryService _categoryService;

  public CategoryController(ICategoryService categoryService)
  {
    _categoryService = categoryService;
  }

  [HttpGet]
  [Route("GetAllCategories")]
  public async Task<IActionResult> GetAllCategories()
  {
    try
    {
      return Ok(await _categoryService.GetAllCategories());
    }catch(Exception ex)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, ex);
    }
  }

  [HttpGet]
  [Route("GetAllCategoriesWithPictures")]
  public async Task<IActionResult> GetAllCategoriesWithPictures()
  {
    try
    {
      var result = await _categoryService.GetAllCategoriesWithPictures();
      return Ok(result);
    }
    catch(Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }
}

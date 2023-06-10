using CantinaUPT_API.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CantinaUPT_API.Web.Controllers;
[Route("api/portion")]
[ApiController]
[Authorize(Roles = "Manager")]
public class PortionController: ControllerBase
{
  private readonly IPortionService _portionService;
  public PortionController(IPortionService portionService)
  {
    _portionService = portionService;
  }

  [HttpGet]
  [Route("GetAllPortions")]
  public async Task<IActionResult> GetAllPortions()
  {
    try
    {
      return Ok(await _portionService.GetAllPortions());
    }
    catch (Exception ex)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, ex);
    }
  }
}

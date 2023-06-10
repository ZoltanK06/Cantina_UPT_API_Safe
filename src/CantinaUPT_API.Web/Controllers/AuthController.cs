using AutoMapper;
using CantinaUPT_API.Core.Interfaces;
using CantinaUPT_API.Core.ProjectAggregate;
using CantinaUPT_API.SharedKernel.AppConstants;
using CantinaUPT_API.Web.ApiModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CantinaUPT_API.Web.Controllers;
[Route("api/Auth")]
[ApiController]
public class AuthController : ControllerBase
{
  private readonly IAuthService _authService;
  private readonly IMapper _mapper;
  private readonly ICanteenService _canteenService;
  private readonly IUserRoleService _roleService;
  public AuthController(IAuthService authService, IMapper mapper, ICanteenService canteenService, IUserRoleService roleService)
  {
    _authService = authService;
    _mapper = mapper;
    _canteenService = canteenService;
    _roleService = roleService;
  }

  [HttpPost]
  [Route("Register")]
  public async Task<IActionResult> Register([FromBody]RegisterRequestDTO user)
  {

    var password = _authService.CreatePasswordHash(user.Password);

    User newUser = new User
    {
      Username = user.Username,
      PasswordHash = password.PasswordHash,
      PasswordSalt = password.PasswordSalt,
      Email = user.Email,
    };

    var role = await _roleService.GetRoleById(user.RoleId);
    newUser.Role = role;

    var canteen = await _canteenService.GetCanteenById(user.CanteenId);
    newUser.Canteen = canteen;

    var result = await _authService.Register(newUser);

    if (result)
    {
      return Ok(result);
    }
    else
    {
      return StatusCode(StatusCodes.Status400BadRequest, AppConstants.UsernameOrEmailAlreadyInUse);
    }
  }

  [HttpPost]
  [Route("Login")]
  public async Task<IActionResult> Login([FromBody]LoginRequestDTO userDto)
  {
    var result = await _authService.Login(_mapper.Map<LoginRequest>(userDto));
    
    if(result.Error == AppConstants.UserNotFound)
    {
      return Unauthorized(AppConstants.UsernameOrEmailWrong);
    }
    if(result.Error == AppConstants.WrongPassword)
    {
      return Unauthorized(AppConstants.WrongPassword);
    }

    return Ok(result);
  }

  [HttpGet]
  [Route("GetAllManagers")]
  [Authorize(Roles = "Admin")]
  public async Task<IActionResult> GetAllManagers()
  {
    try
    {
      var result = await _authService.GetAllManagers();
      return Ok(_mapper.Map<List<UserDTO>>(result));
    }
    catch(Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpDelete]
  [Route("DeleteUser")]
  [Authorize(Roles = "Admin")]
  public async Task<IActionResult> DeleteUser([FromQuery]int userId)
  {
    try
    {
      await _authService.DeleteUser(userId);
      return Ok();
    }
    catch(Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
  }

  [HttpPut]
  [Route("UpdateUser")]
  [Authorize(Roles = "Admin")]
  public async Task<IActionResult> UpdateUser([FromBody] RegisterRequestDTO newUser)
  {
    try
    {
      var canteen = await _canteenService.GetCanteenById(newUser.CanteenId);
      var role = await _roleService.GetRoleById(newUser.RoleId);
      User user;
      if(newUser.Password != null)
      {
        var password = _authService.CreatePasswordHash(newUser.Password);
        user = new User
        {
          Canteen = canteen,
          Role = role,
          Username = newUser.Username,
          Email = newUser.Email,
          PasswordHash = password.PasswordHash,
          PasswordSalt = password.PasswordSalt
        };
      }
      else
      {
        user = new User
        {
          Canteen = canteen,
          Role = role,
          Username = newUser.Username,
          Email = newUser.Email
        };
      }
      
      await _authService.UpdateUser(user);
      return Ok();
    }
    catch(Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError);
    }
    
  }
}

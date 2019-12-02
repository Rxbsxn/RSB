using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RetroShop.Models;
using RetroShop.Services;

namespace RetroShop.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
      _userService = userService;
    }

    public ActionResult<List<User>> Get()
    {
      return _userService.Get();
    }
  }
}
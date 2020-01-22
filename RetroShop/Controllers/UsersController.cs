using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RetroShop.Models;
using RetroShop.Requests;
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

    [HttpGet]
    public ActionResult<List<User>> Get()
    {
      return _userService.Get();
    }

    [HttpGet("{id:length(24)}")]
    public ActionResult<User> Get(string id)
    {
      var user = _userService.Get(id);

      if (user == null)
      {
        return NotFound();
      }

      return user;
    }

    [HttpPost]
    public ActionResult<User> Create(User user)
    {
      _userService.Create(user);
      return user;
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, UserRequest newUserRequest)
    {
      var newUser = new User(id, newUserRequest.FirstName);
      var user = _userService.Get(id);

      if (user == null)
      {
        return NotFound();
      }
      
      _userService.Update(id, newUser);

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      _userService.Remove(id);

      return NoContent();
    }
  }
}
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
  public class AuctionsController : ControllerBase
  {
    private readonly AuctionService _auctionService;

    public AuctionsController(AuctionService auctionService)
    {
      _auctionService = auctionService;
    }

    [HttpGet]
    public ActionResult<List<Auction>> Get()
    {
      return _auctionService.Get();
    }

    [HttpGet("{id:length(24)}")]
    public ActionResult<Auction> Get(string id)
    {
      var user = _auctionService.Get(id);

      if (user == null)
      {
        return NotFound();
      }

      return user;
    }

    [HttpPost]
    public ActionResult<Auction> Create(Auction auction)
    {
      _auctionService.Create(auction);
      return auction;
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, UserRequest newUserRequest)
    {
      var newUser = new User(id, newUserRequest.FirstName);
      var user = _auctionService.Get(id);

      if (user == null)
      {
        return NotFound();
      }
      
//      _auctionService.Update(id, newUser); TODO

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      _auctionService.Remove(id);

      return NoContent();
    }
  }
}
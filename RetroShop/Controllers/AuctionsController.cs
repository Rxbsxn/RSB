using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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
    private readonly UserService _userService;

    public AuctionsController(AuctionService auctionService, UserService userService)
    {
      _auctionService = auctionService;
      _userService = userService;
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
    public IActionResult Update(string id, AuctionRequest newAuctionAuctionRequest)
    {
      var auction = _auctionService.Get(id);

      if (auction == null)
      {
        return NotFound();
      }
      
      var newAuction = new Auction(id, newAuctionAuctionRequest.Name, newAuctionAuctionRequest.Description, newAuctionAuctionRequest.OwnerId, newAuctionAuctionRequest.Price);
      _auctionService.Update(id, newAuction);

      var creator = _userService.Get(newAuctionAuctionRequest.OwnerId);
      creator?.Auctions.Add(new ObjectId(id));
      
      _userService.Update(newAuctionAuctionRequest.OwnerId, creator);

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
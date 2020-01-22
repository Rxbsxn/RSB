using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using RetroShop.Models;
using RetroShop.Utils;

namespace RetroShop.Services
{
  public class AuctionService
  {
    private readonly IMongoCollection<Auction> _auctions;

    public AuctionService(IDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _auctions = database.GetCollection<Auction>("Auction");
    }

    public List<Auction> Get()
    {
      return _auctions.Find(auction => true).ToList();
    }

    public Auction Get(string id)
    {
      return _auctions.Find<Auction>(auction => auction.Id == id).FirstOrDefault();
    }

    public Auction Create(Auction auction)
    {
      _auctions.InsertOne(auction);
      return auction;
    }

    public void Update(string id, Auction newAuction)
    {
      _auctions.ReplaceOne(auction => auction.Id == id, newAuction);
    }

    public void Remove(Auction auctionToDelete)
    {
      _auctions.DeleteOne(auction => auction.Id == auctionToDelete.Id);
    }

    public void Remove(string id)
    {
      _auctions.DeleteOne(auction => auction.Id == id);
    }
  }
}
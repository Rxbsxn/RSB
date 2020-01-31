using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RetroShop.Models
{
  public class Auction : IAuction
  {
    public Auction(string id, string name, string description, string ownerId, int price)
    {
      Id = id;
      Name = name;
      Description = description;
      OwnerId = ownerId;
      Price = price;

    }

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    [BsonRepresentation(BsonType.ObjectId)]
    public string OwnerId { get; set; }
    public int Price { get; set; }
  }
}
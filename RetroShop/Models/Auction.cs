using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RetroShop.Models
{
  public class Auction : IAuction
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ObjectId OwnerId { get; set; }
    public int Price { get; set; }
  }
}
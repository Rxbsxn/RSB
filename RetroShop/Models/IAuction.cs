using MongoDB.Bson;

namespace RetroShop.Models
{
  public interface IAuction
  {
    string Id { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    string OwnerId { get; set; }
    int Price { get; set; }
    
  }
}
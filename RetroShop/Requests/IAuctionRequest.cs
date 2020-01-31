using MongoDB.Bson;

namespace RetroShop.Requests
{
  public interface IAuctionRequest
  {
    string Name { get; set; }
    string Description { get; set; }
    string OwnerId { get; set; }
    int Price { get; set; }
  }
}
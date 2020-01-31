using MongoDB.Bson;

namespace RetroShop.Requests
{
  public class AuctionRequest : IAuctionRequest
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public string OwnerId { get; set; }
    public int Price { get; set; }
  }
}
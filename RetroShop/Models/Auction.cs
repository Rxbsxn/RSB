namespace RetroShop.Models
{
  public class Auction : IAuction
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public User Owner { get; set; }
    public int Price { get; set; }
  }
}
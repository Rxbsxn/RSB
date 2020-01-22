using System.Collections;
using System.Collections.Generic;

namespace RetroShop.Models
{
  public interface IUser
  {
    string Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
    ICollection<Auction> Auctions {get; set;}
  }
}
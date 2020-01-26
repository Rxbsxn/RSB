using System.Collections;
using System.Collections.Generic;
using MongoDB.Bson;

namespace RetroShop.Models
{
  public interface IUser
  {
    string Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
    ICollection<ObjectId> Auctions {get; set;}
  }
}
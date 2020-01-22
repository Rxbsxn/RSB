using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RetroShop.Models
{
  public class User : IUser
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public User(string id, string firstName, string lastName, string email)
    {
      Id = id;
      FirstName = firstName;
      LastName = lastName;
      Email = email;
    }

    public User(string id, string firstName)
    {
      Id = id;
      FirstName = firstName;
    }
  }
}
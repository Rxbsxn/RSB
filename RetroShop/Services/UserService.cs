using System.Collections.Generic;
using MongoDB.Driver;
using RetroShop.Models;
using RetroShop.Utils;

namespace RetroShop.Services
{
  public class UserService
  {
    private readonly IMongoCollection<User> _users;

    public UserService(IDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _users = database.GetCollection<User>(settings.UserCollection);
    }

    public List<User> Get()
    {
      return _users.Find(user => true).ToList();
    }

    public User Get(string id)
    {
      return _users.Find<User>(user => user.Id == id).FirstOrDefault();
    }

    public User Create(User user)
    {
      _users.InsertOne(user);
      return user;
    }

    public User Update(string id, User newUser)
    {
      _users.ReplaceOne(user => user.Id == id, newUser);
      return newUser;
    }

    public void Remove(string id)
    {
      _users.DeleteOne(user => user.Id == id);
    }
  }
}
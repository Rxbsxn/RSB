namespace RetroShop.Requests
{
  public interface IUserRequest
  {
    string FirstName { get; set; } 
    string LastName { get; set; }
    string Email { get; set; }
  }
}
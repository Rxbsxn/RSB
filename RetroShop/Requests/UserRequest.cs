namespace RetroShop.Requests
{
  public class UserRequest : IUserRequest
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
  }
}
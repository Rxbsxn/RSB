namespace RetroShop.Models
{
  public interface IUser
  {
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
  }
}
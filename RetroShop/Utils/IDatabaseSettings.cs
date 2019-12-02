namespace RetroShop.Utils
{
  public interface IDatabaseSettings
  {
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
    string UserCollection { get; set; }
  }
}
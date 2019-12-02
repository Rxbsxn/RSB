namespace RetroShop.Utils
{
  public class DatabaseSettings : IDatabaseSettings
  {
    public string UserCollection { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }

  }
}
namespace UserHandler.Db.Settings
{
    public class UserDbSettings : IDbSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}

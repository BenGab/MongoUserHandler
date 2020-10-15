namespace UserHandler.Db.Settings
{
    public interface IDbSettings
    {
        string CollectionName { get; set; }

        string ConnectionString { get; set; }

        string DatabaseName { get; set; }
    }
}

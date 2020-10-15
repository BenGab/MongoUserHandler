using MongoDB.Driver;

namespace UserHandler.Db
{
    public interface IDbFactory
    {
        IMongoDatabase GetDatabase();
    }
}

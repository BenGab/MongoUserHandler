using MongoDB.Driver;
using System;
using UserHandler.Db.Settings;

namespace UserHandler.Db
{
    public class MongoDbFactory : IDbFactory
    {
        private readonly Lazy<IMongoClient> mongoClient;
        private readonly IDbSettings dbSettings;

        public MongoDbFactory(IDbSettings dbSettings)
        {
            this.mongoClient = new Lazy<IMongoClient>(()=> new MongoClient(dbSettings.ConnectionString));
            this.dbSettings = dbSettings;
        }

        public IMongoDatabase GetDatabase()
        {
            return mongoClient.Value.GetDatabase(dbSettings.DatabaseName);
        }
    }
}

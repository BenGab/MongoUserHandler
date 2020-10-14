using MongoDB.Driver;

namespace UserHandler.Db
{
    public class MongoDbFactory : IDbFactory
    {
        private readonly IMongoClient mongoClient;

        public MongoDbFactory(IMongoClient mongoClient)
        {
            this.mongoClient = mongoClient;
        }

        public IMongoDatabase GetDatabase(string databaseName)
        {
            return mongoClient.GetDatabase(databaseName);
        }
    }
}

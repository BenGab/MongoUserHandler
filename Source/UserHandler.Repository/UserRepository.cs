using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using UserHandler.Db;
using UserHandler.Db.Models;
using UserHandler.Db.Settings;

namespace UserHandler.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly Lazy<IMongoCollection<User>> userCollection;

        public UserRepository(IDbSettings dbSettings, IDbFactory dbFactory)
        {
           
            userCollection = new Lazy<IMongoCollection<User>>(() =>
            {
                IMongoDatabase database = dbFactory.GetDatabase();
                return database.GetCollection<User>(dbSettings.CollectionName);
            }, true);
        }

        public User Create(User entitiy)
        {
            userCollection.Value.InsertOne(entitiy);
            return entitiy;
        }

        public ICollection<User> GetAll()
        {
            return userCollection.Value.Find(user => true).ToList();
        }

        public ICollection<User> GetBy(Expression<Func<User, bool>> filter)
        {
            return userCollection.Value.Find(filter).ToList();
        }

        public User GetById(int id)
        {
            return userCollection.Value.Find(user => user.Id == id).SingleOrDefault();
        }

        public DeleteResult Remove(User entiy)
        {
           return userCollection.Value.DeleteOne(user => user.Id == entiy.Id);
        }

        public DeleteResult Remove(int id)
        {
            return userCollection.Value.DeleteOne(user=> user.Id == id);
        }

        public ReplaceOneResult Update(User entitiy)
        {
            return userCollection.Value.ReplaceOne(user => user.Id == entitiy.Id, entitiy);
        }
    }
}

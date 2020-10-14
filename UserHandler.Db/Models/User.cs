using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserHandler.Db.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Website { get; set; }

        public Company Company { get; set; }
    }
}

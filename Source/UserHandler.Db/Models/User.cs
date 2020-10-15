using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace UserHandler.Db.Models
{
    public class User
    {
        [BsonId]
        [BsonElement("id")]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("username")]
        [BsonElement("username")]
        public string UserName { get; set; }

        [JsonProperty("email")]
        [BsonElement("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        [BsonElement("phone")]
        public string Phone { get; set; }

        [JsonProperty("website")]
        [BsonElement("website")]
        public string Website { get; set; }

        [JsonProperty("company")]
        [BsonElement("company")]
        public Company Company { get; set; }

        [JsonProperty("address")]
        [BsonElement("address")]
        public Address Address { get; set; }
    }
}

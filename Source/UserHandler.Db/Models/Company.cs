using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace UserHandler.Db.Models
{
    public class Company
    {
        [BsonElement("name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [BsonElement("catchPhrase")]
        [JsonProperty("catchPhrase")]
        public string CatchPhrase { get; set; }

        [JsonProperty("bs")]
        [BsonElement("bs")]
        public string Bs { get; set; }
    }
}

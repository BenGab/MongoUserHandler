using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace UserHandler.Db.Models
{
    public class Address
    {
        [BsonElement("street")]
        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("suite")]
        [BsonElement("suite")]
        public string Suite { get; set; }

        [BsonElement("city")]
        [JsonProperty("city")]
        public string City { get; set; }

        [BsonElement("zipcode")]
        [JsonProperty("zipcode")]
        public string ZipCode { get; set; }

        [BsonElement("geo")]
        [JsonProperty("geo")]
        public Location Location { get; set; }
    }
}

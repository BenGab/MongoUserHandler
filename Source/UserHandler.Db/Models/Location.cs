using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace UserHandler.Db.Models
{
    public class Location
    {
        [BsonElement("lat")]
        [JsonProperty("lat")]
        public double Lattitude { get; set; }

        [BsonElement("lng")]
        [JsonProperty("lng")]
        public double Longitude { get; set; }
    }
}
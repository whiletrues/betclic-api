using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Betclic.Ranking.Entities.Entities
{
    public class Participation
    {
        [BsonRepresentation(BsonType.ObjectId), BsonId]
        [JsonPropertyName("id"), BsonElement("id")]
        public string? Id { get; set; }

        [BsonRequired, JsonRequired]
        [JsonPropertyName("player"), BsonElement("player")]
        public string? Player { get; set; }

        [BsonRequired, JsonRequired]
        [JsonPropertyName("tournament"), BsonElement("tournament")]
        public string? Tournament { get; set; }

        [BsonRequired, JsonRequired]
        [JsonPropertyName("points"), BsonElement("points")]
        public int Points { get; set; }

        [JsonPropertyName("timestamp"), BsonElement("timestamp")]
        public DateTime? TimeStamp { get; set; }
    }
}

using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Betclic.Ranking.Entities.Entities
{
    public record class ParticipationSummary
    {
        [BsonRequired, JsonRequired]
        [JsonPropertyName("player"), BsonElement("player")]
        public string? Player { get; set; }

        [BsonRequired, JsonRequired]
        [JsonPropertyName("tournament"), BsonElement("tournament")]
        public string? Tournament { get; set; }

        [BsonRequired, JsonRequired]
        [JsonPropertyName("points"), BsonElement("points")]
        public int Points { get; set; }

    }
}

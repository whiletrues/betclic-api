using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Betclic.Ranking.API.Models
{
    public class Player
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId), BsonId]
        [JsonPropertyName("id"), BsonElement("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonRequired, BsonRequired]
        [JsonPropertyName("name"), BsonElement("name")]
        public required string Name { get; set; }
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Betclic.Ranking.Entities.Entities
{

    public class Tournament
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId), BsonId]
        [JsonPropertyName("id"), BsonElement("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        [BsonRequired, JsonRequired]
        [JsonPropertyName("name"), BsonElement("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        [JsonPropertyName("start"), BsonElement("start")]
        public DateTime Start { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        [JsonPropertyName("end"), BsonElement("end")]
        public DateTime End { get; set; }
    }
}

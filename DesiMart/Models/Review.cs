using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DesiMart.Models
{
    public class Review
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string UserId { get; set; }
        public string Comment { get; set; }
        public decimal Rating { get; set; }
        public string ProductId { get; set; }
        public DateTime ReviewDate { get; set; } = DateTime.UtcNow;
    }
}

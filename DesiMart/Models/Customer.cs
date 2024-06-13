using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DesiMart.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string? Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Role { get; set; }
        public List<Order>? Orders { get; set; }
    }
}

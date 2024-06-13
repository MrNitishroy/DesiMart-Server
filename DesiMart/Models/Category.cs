using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DesiMart.Models
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}

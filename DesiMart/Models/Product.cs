using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DesiMart.Models
{
    public class Product
    {
        [BsonId]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        [BsonRepresentation(BsonType.String)]
        public List<ProductUnit> Units { get; set; } = [];
        public decimal Stock { get; set; }
        public List<string> Categories { get; set; } = [];
        public List<ProductImage> Images { get; set; } = [];
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
 
    }

    public class ProductUnit
    {
        public string Name { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public decimal ConversionFactor { get; set; }
    }
    public class ProductImage
    {
        public string Url { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
    }
  

}

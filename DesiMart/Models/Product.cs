﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DesiMart.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Stock { get; set; }
        public decimal SellPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public string? Unit { get;set; }
        public decimal UnitPrice { get; set; }
        public List<string> Tags { get; set; } = [];
        public string Category { get; set; } = "uncategoryzed";
        public List<string> Images { get; set; } = [];
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
        public List<Review> Reviews { get; set; } = new List<Review>();
        public decimal Discount { get; set; } = 0;
        public DateTime DiscountStartDate { get; set; }
        public DateTime DiscountEndDate { get; set; }
        public string Supplier { get; set; } = string.Empty;
        public decimal AverageRating { get; set; } = 0;
    }

   
  

}

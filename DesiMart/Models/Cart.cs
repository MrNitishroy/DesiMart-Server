using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DesiMart.Models
{
    public class Cart
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<CartItem> CartItems { get; set; }
        public decimal TotalAmount
        {
            get
            {
                return  CartItems.Sum(ci => ci.TotalPrice);
            }
        }
    }
}

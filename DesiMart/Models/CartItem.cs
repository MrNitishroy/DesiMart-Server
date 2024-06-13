using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DesiMart.Models
{
    public class CartItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice
        {
            get
            {
                return Quantity * Product.SellPrice;
            }
        }
    }
}

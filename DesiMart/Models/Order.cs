using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DesiMart.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }

    public enum PaymentMethod
    {
        Cash,
        Card,
        UPI,
        NetBanking,
        Wallet,
        EMI,
        COD
    }
}



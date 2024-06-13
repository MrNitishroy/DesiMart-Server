namespace DesiMart.Models
{
    public class Review
    {
        public string UserId { get; set; }
        public string Comment { get; set; }
        public decimal Rating { get; set; }
        public DateTime ReviewDate { get; set; } = DateTime.UtcNow;
    }
}

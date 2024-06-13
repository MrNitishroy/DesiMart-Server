namespace DesiMart.Models.Request
{
    public class UpdateProduct
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Stock { get; set; }
        public decimal SellPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public string? Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public List<string> Tags { get; set; } = [];
        public string Category { get; set; } 
        public List<string> Images { get; set; } = [];
        public bool IsActive { get; set; } = true;
        public List<Review> Reviews { get; set; } = new List<Review>();
        public decimal Discount { get; set; } = 0;
        public DateTime DiscountStartDate { get; set; }
        public DateTime DiscountEndDate { get; set; }
        public string Supplier { get; set; } = string.Empty;
        public decimal AverageRating { get; set; } = 0;
    }
}

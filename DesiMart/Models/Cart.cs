﻿namespace DesiMart.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
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
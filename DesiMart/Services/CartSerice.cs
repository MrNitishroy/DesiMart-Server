using DesiMart.Models;
using DesiMart.Services.Interfaces;

namespace DesiMart.Services
{
    public class CartSerice : ICart
    {
        public Task<ResponseModel> AddToCart(Cart cart)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCart(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cart>> GetCart()
        {
            throw new NotImplementedException();
        }

        public Task<List<Cart>> GetCartByCustomerId(string customerId)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> GetCartById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> UpdateCart(Cart cart, string id)
        {
            throw new NotImplementedException();
        }
    }
}

using DesiMart.Models;

namespace DesiMart.Services.Interfaces
{
    public interface ICart
    {
        Task<ResponseModel> AddToCart(Cart cart);
        Task<ResponseModel> UpdateCart(Cart cart, string id);
        Task DeleteCart(string id);
        Task<Cart> GetCartById(string id);
        Task<Cart> GetCartByCustomerId(string customerId);
        Task<List<Cart>> GetCart();
        Task<ResponseModel> UpdateCartItems(string cartId, CartItem cartItems);
    }
}

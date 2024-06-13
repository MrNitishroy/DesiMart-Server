using DesiMart.DbContext;
using DesiMart.Models;
using DesiMart.Models.Request;
using DesiMart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Routing;
using MongoDB.Driver;

namespace DesiMart.Services
{
    public class CartService : ICart
    {
        private readonly IMongoCollection<Cart> _cartCollection;

        public CartService(MongoDbContext mongoDbContext)
        {
            _cartCollection = mongoDbContext.CartDb;
        }
        public async Task<ResponseModel> AddToCart(Cart cart)
        {
           if(cart.CartItems.Count==0)
            {
                return await Task.FromResult(new ResponseModel("Cart is empty", false, null));
            }
            _cartCollection.InsertOne(cart);
            

            return await Task.FromResult(new ResponseModel("Cart added successfully", true, cart));

        }

        public async Task DeleteCart(string id)
        {
             await   _cartCollection.DeleteOneAsync(cart => cart.Id == id);
        }

        public async Task<List<Cart>> GetCart()
        {
            var carts = await _cartCollection.Find(cart => true).ToListAsync();
            return carts;
        }

        public async Task<Cart> GetCartByCustomerId(string customerId)
        {
            var cart = await _cartCollection
                         .Find(c => c.CustomerId == customerId)
                         .FirstOrDefaultAsync();
            return cart;
        }

        public async Task<Cart> GetCartById(string id)
        {
            var cart = await _cartCollection
                        .Find(c => c.Id == id)
                        .FirstOrDefaultAsync();
            return cart;
        }

        public async Task<ResponseModel> UpdateCart(Cart cart, string id)
        {
            var existingCart = await _cartCollection.Find(a => a.Id == id).FirstOrDefaultAsync();

            if (existingCart == null)
            {
                return new ResponseModel("Cart not found", false, null);
            }
            await _cartCollection.ReplaceOneAsync(a => a.Id == id, existingCart);
            return new ResponseModel("Product updated successfully", true, existingCart);

        }

        public async Task<ResponseModel> UpdateCartItems(string cartId, CartItem cartItem)
        {
            var existingCart = await _cartCollection.Find(a => a.Id == cartId).FirstOrDefaultAsync();
            if (existingCart == null)
            {
                return new ResponseModel("Cart not found", false, null);
            }

            existingCart.CartItems.Add(cartItem);

            var updateResult = await _cartCollection.ReplaceOneAsync(a => a.Id == cartId, existingCart);
            if (updateResult.IsAcknowledged && updateResult.ModifiedCount > 0)
            {
                return new ResponseModel("Cart updated successfully", true, existingCart);
            }

            return new ResponseModel("Failed to update cart", false, null);
        }

    }
}

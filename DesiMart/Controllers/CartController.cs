using DesiMart.Models;
using DesiMart.Models.Request;
using DesiMart.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesiMart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICart _cartService;

        public CartController(ICart cartService)
        {
            _cartService = cartService;
        }

        // GET: api/cart
        [HttpGet]
        public async Task<ActionResult<List<Cart>>> GetCarts()
        {
            try
            {
                var carts = await _cartService.GetCart();
                return Ok(carts);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving carts: " + ex.Message);
            }
        }

        // GET: api/cart/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCartById(string id)
        {
            try
            {
                var cart = await _cartService.GetCartById(id);
                if (cart == null)
                {
                    return NotFound("Cart not found");
                }
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving cart: " + ex.Message);
            }
        }

        // POST: api/cart
        [HttpPost]
        public async Task<ActionResult<ResponseModel>> AddToCart([FromBody] Cart cart)
        {
            try
            {
                var response = await _cartService.AddToCart(cart);
                if (!response.Success)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding to cart: " + ex.Message);
            }
        }

        // PUT: api/cart/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseModel>> UpdateCart(string id, [FromBody] Cart cart)
        {
            try
            {
                var response = await _cartService.UpdateCart(cart, id);
                if (!response.Success)
                {
                    return NotFound(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating cart: " + ex.Message);
            }
        }

        // PUT: api/cart/{cartId}/items
        [HttpPut("{cartId}/items")]
        public async Task<ActionResult<ResponseModel>> UpdateCartItems(string cartId, [FromBody] CartItem cartItem)
        {
            try
            {
                var response = await _cartService.UpdateCartItems(cartId, cartItem);
                if (!response.Success)
                {
                    return NotFound(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating cart items: " + ex.Message);
            }
        }

        // DELETE: api/cart/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCart(string id)
        {
            try
            {
                await _cartService.DeleteCart(id);
                return Ok("Cart deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting cart: " + ex.Message);
            }
        }
    }
}

using DesiMart.Models;
using DesiMart.Models.Request;
using DesiMart.Services;
using DesiMart.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesiMart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

       public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        /// <summary>
        /// Get all products.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            try
            {
                var products = await productService.GetProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get a product by Id.
        /// </summary>
        /// <param name="id">The product ID.</param>
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(string id)
        {
            try
            {
                var product = await productService.GetProductById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get products by name.
        /// </summary>
        /// <param name="name">The product name.</param>
        [HttpGet("name")]
        public async Task<ActionResult<List<Product>>> GetProductByName([FromQuery] string name)
        {
            try
            {
                var products = await productService.GetProductsByName(name);
                if (products == null || products.Count == 0)
                {
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Adds a new product.
        /// </summary>
        /// <param name="product">The product to add.</param>
        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
            var response = await productService.AddProduct(product);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(500, response);
            }

        }

        /// <summary>
        /// Update Product 
        /// </summary>
        /// <param name="product">Update product </param>

        [HttpPut]
        public async Task<ActionResult> UpdateProduct([FromQuery]string id ,[FromBody] UpdateProduct product)
        {

            
            try
            {
                await productService.UpdateProduct(product, id);
                return Ok(product);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Delete Product 
        /// </summary>
        /// <param name="product">Delete Product</param>

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(string id)
        {
            try
            {
                await productService.DeleteProduct(id);
                return Ok("Product Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }


}

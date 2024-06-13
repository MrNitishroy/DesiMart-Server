using DesiMart.DbContext;
using DesiMart.Models;
using DesiMart.Models.Request;
using DesiMart.Services.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DesiMart.Services
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _collection;
        private readonly ILogger<ProductService> _logger;
        public ProductService(MongoDbContext mongoDbContext, ILogger<ProductService> logger)
        {
            _collection = mongoDbContext.ProductDb;
            _logger = logger;
        }

        public async Task<ResponseModel> AddProduct(Product product)
        {
            if (product == null)
            {
                return new ResponseModel("Product is null", false, null);
            }

            if (string.IsNullOrEmpty(product.Name))
            {
                return new ResponseModel("Product name is not provided", false, null);
            }

            if (string.IsNullOrEmpty(product.Category))
            {
                return new ResponseModel("Product category is not provided", false, null);
            }
            try
            {
                await _collection.InsertOneAsync(product);
                return new ResponseModel("Product added successfully", true, product);
            }
            catch (Exception ex)
            {
                return new ResponseModel($"An error occurred: {ex.Message}", false, null);
            }
        }

        public async Task DeleteProduct(string id)
        {
            await _collection.DeleteOneAsync(id);
        }

       // public async Task<List<Product>> GetProducts(int pageNumber, int pageSize)
       // {
       //     return await _collection.Find(a => true)
       //                             .Skip((pageNumber - 1) * pageSize)
         //                           .Limit(pageSize)
           //                         .ToListAsync();
       // }
        public async Task<List<Product>> SearchProducts(string category = null, decimal? minPrice = null, decimal? maxPrice = null)
        {
            var filterBuilder = Builders<Product>.Filter;
            var filter = filterBuilder.Empty;

            if (!string.IsNullOrEmpty(category))
            {
                filter &= filterBuilder.Eq(p => p.Category, category);
            }

            if (minPrice.HasValue)
            {
                filter &= filterBuilder.Gte(p => p.SellPrice, minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                filter &= filterBuilder.Lte(p => p.SellPrice, maxPrice.Value);
            }
            return await _collection.Find(filter).ToListAsync();
        }
        public async Task<ResponseModel> AddProducts(List<Product> products)
        {
            if (products == null || products.Count == 0)
            {
                return new ResponseModel("Product list is empty", false, null);
            }

            try
            {
                await _collection.InsertManyAsync(products);
                return new ResponseModel("Products added successfully", true, products);
            }
            catch (Exception ex)
            {
                return new ResponseModel($"An error occurred: {ex.Message}", false, null);
            }
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _collection.Find(a=>true).ToListAsync();
        }

        public async Task<Product> GetProductById(string id)
        {
            return await _collection.Find(a =>a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ResponseModel> UpdateProduct(UpdateProduct updateProduct, string id)
        {
            var existingProduct = await _collection.Find(a => a.Id == id).FirstOrDefaultAsync();
            if (existingProduct == null)
            {
                return new ResponseModel("Product not found", false, null);
            }
            // Update only the provided fields
            if (!string.IsNullOrEmpty(updateProduct.Name))
            {
                existingProduct.Name = updateProduct.Name;
            }
            if (!string.IsNullOrEmpty(updateProduct.Description))
            {
                existingProduct.Description = updateProduct.Description;
            }
            if (updateProduct.Stock > 0)
            {
                existingProduct.Stock = updateProduct.Stock;
            }
            if (updateProduct.SellPrice > 0)
            {
                existingProduct.SellPrice = updateProduct.SellPrice;
            }
            if (updateProduct.PurchasePrice > 0)
            {
                existingProduct.PurchasePrice = updateProduct.PurchasePrice;
            }
            if (!string.IsNullOrEmpty(updateProduct.Unit))
            {
                existingProduct.Unit = updateProduct.Unit;
            }
            if (updateProduct.UnitPrice > 0)
            {
                existingProduct.UnitPrice = updateProduct.UnitPrice;
            }
            if (updateProduct.Tags != null && updateProduct.Tags.Any())
            {
                existingProduct.Tags = updateProduct.Tags;
            }
            if (!string.IsNullOrEmpty(updateProduct.Category))
            {
                existingProduct.Category = updateProduct.Category;
            }
            if (updateProduct.Images != null && updateProduct.Images.Any())
            {
                existingProduct.Images = updateProduct.Images;
            }
            existingProduct.IsActive = updateProduct.IsActive; // Assuming this field should always be updated

            if (updateProduct.Reviews != null && updateProduct.Reviews.Any())
            {
                existingProduct.Reviews = updateProduct.Reviews;
            }
            if (updateProduct.Discount >= 0)
            {
                existingProduct.Discount = updateProduct.Discount;
            }
            if (updateProduct.DiscountStartDate != DateTime.MinValue)
            {
                existingProduct.DiscountStartDate = updateProduct.DiscountStartDate;
            }
            if (updateProduct.DiscountEndDate != DateTime.MinValue)
            {
                existingProduct.DiscountEndDate = updateProduct.DiscountEndDate;
            }
            if (!string.IsNullOrEmpty(updateProduct.Supplier))
            {
                existingProduct.Supplier = updateProduct.Supplier;
            }
            if (updateProduct.AverageRating >= 0)
            {
                existingProduct.AverageRating = updateProduct.AverageRating;
            }

            // Save the updated product back to the database
            await _collection.ReplaceOneAsync(a => a.Id == id, existingProduct);
            return new ResponseModel("Product updated successfully", true, existingProduct);
        }

        public async Task<List<Product>> GetProductsByName(string name)
        {

            var filter = Builders<Product>.Filter.Regex("Name", new BsonRegularExpression(name, "i"));

            // Perform the search
            List<Product> products = await _collection.Find(filter).ToListAsync();

            return products;
        }
        public async Task<List<Product>> SearchProduct(string keyword)
        {
            // Create a case-insensitive regular expression pattern
            var regex = new BsonRegularExpression(keyword, "i");

            // Construct the filter
            var filter = Builders<Product>.Filter.Or(
                Builders<Product>.Filter.Regex("Name", regex),
                Builders<Product>.Filter.Regex("Category", regex),
                Builders<Product>.Filter.Regex("Description", regex),
                Builders<Product>.Filter.AnyEq("Tags", regex)
            );

            // Perform the search
            List<Product> products = await _collection.Find(filter).ToListAsync();

            return products;
        }



    }
}

using DesiMart.DbContext;
using DesiMart.Models;
using DesiMart.Services.Interfaces;
using MongoDB.Driver;

namespace DesiMart.Services
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _collection;
   
        public ProductService(MongoDbContext<Product> mongoDbContext)
        {
            _collection = mongoDbContext.Collection;
        }

        public async Task AddProduct(Product product)
        {
            await _collection.InsertOneAsync(product);
        }

        public async Task DeleteProduct(string id)
        {
            await _collection.DeleteOneAsync(id);
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _collection.Find(a=>true).ToListAsync();
        }

        public async Task<Product> GetProductById(string id)
        {
            return await _collection.Find(a =>a.Id == id).FirstOrDefaultAsync();
        }

        public Task UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

       
    }
}

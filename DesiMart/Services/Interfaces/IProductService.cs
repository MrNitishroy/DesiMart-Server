using DesiMart.Models;

namespace DesiMart.Services.Interfaces
{
    public interface IProductService
    {
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(string id);
        Task<Product> GetProductById(string id);
        Task<Product> GetProductByName(string name);
        Task<List<Product>> GetProducts();

    }
}

using DesiMart.Models;
using DesiMart.Models.Request;

namespace DesiMart.Services.Interfaces
{
    public interface IProductService
    {
        Task<ResponseModel> AddProduct(Product product);
        Task<ResponseModel> UpdateProduct(UpdateProduct product,string id);
        Task DeleteProduct(string id);
        Task<Product> GetProductById(string id);
        Task<List<Product>> GetProductsByName(string name);
        Task<List<Product>> GetProducts();

      

    }
}

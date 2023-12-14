using MyShop.Models;
using MyShop.Models.Dtos;

namespace MyShop.Services.IServices
{
    public interface IProduct
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(Guid id);
        Task<string> AddProductAsync(Product product);
        Task<string> UpdateProductAsync(Product product);
        Task<string> DeleteProductAsync(Product Product);
    }
}

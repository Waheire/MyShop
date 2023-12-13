using MyShop.Dtos;
using MyShop.Models;

namespace MyShop.Services.IServices
{
    public interface IProduct
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(Guid id);
        Task<string> AddProductAsync(AddProduct newProduct);
        Task<string> UpdateProductAsync(Guid id, AddProduct updatedProduct);
        Task<string> DeleteProductAsync(AddProduct Product);
    }
}

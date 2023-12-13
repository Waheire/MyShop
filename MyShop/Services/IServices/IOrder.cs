using MyShop.Dtos;
using MyShop.Models;

namespace MyShop.Services.IServices
{
    public interface IOrder
    {
        Task<List<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(Guid id);
        Task<string> AddOrderAsync(AddProduct newProduct);
        Task<string> UpdateProductAsync(Guid id, AddProduct updatedProduct);
        Task<string> DeleteProductAsync(AddProduct Product);
    }
}

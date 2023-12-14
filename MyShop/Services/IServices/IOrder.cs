using MyShop.Models;
using MyShop.Models.Dtos;

namespace MyShop.Services.IServices
{
    public interface IOrder
    {
        Task<List<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(Guid id);
        Task<string> AddOrderAsync(Order order);
        Task<string> UpdateOrderAsync(Order order);
        Task<string> DeleteOrderAsync(Order order);
    }
}

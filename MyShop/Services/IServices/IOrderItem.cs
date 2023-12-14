using MyShop.Models;

namespace MyShop.Services.IServices
{
    public interface IOrderItem
    {
        Task<List<OrderItem>> GetOrderItemsAsync();
        Task<OrderItem> GetOrderItemByIdAsync(Guid id);
        Task<string> AddOrderItemAsync(OrderItem orderItem);
        Task<string> UpdateOrderItemAsync(OrderItem orderItem);
        Task<string> DeleteOrderItemAsync(OrderItem orderItem);
    }
}

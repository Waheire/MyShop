using Microsoft.EntityFrameworkCore;
using MyShop.Data;
using MyShop.Models;
using MyShop.Services.IServices;

namespace MyShop.Services
{
    public class OrderItemService : IOrderItem
    {
        private readonly AppDbContext _context;

        public OrderItemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddOrderItemAsync(OrderItem orderItem)
        {
            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
            return "Order Item added successfully";
        }

        public async Task<string> DeleteOrderItemAsync(OrderItem orderItem)
        {
            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
            return "Order Item Deleted Succesfully";
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(Guid id)
        {
            return await _context.OrderItems.FirstOrDefaultAsync(x => x.orderItemId == id);
        }

        public async Task<List<OrderItem>> GetOrderItemsAsync()
        {
            return await _context.OrderItems.ToListAsync();
        }

        public async Task<string> UpdateOrderItemAsync(OrderItem orderItem)
        {
            _context.OrderItems.Update(orderItem);
            await _context.SaveChangesAsync();
            return "Order Item updated Successfully";
        }
    }
}

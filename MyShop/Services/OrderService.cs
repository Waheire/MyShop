using Microsoft.EntityFrameworkCore;
using MyShop.Data;
using MyShop.Models;
using MyShop.Services.IServices;

namespace MyShop.Services
{
    public class OrderService : IOrder
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddOrderAsync(Order order)
        {
           _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return "Order Added successfully";
        }

        public async Task<string> DeleteOrderAsync(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return "Order Deleted successfully";
        }

        public async Task<Order> GetOrderByIdAsync(Guid id)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == id);
        }

        public Task<List<Order>> GetOrdersAsync()
        {
            return _context.Orders.ToListAsync();
        }

        public async Task<string> UpdateOrderAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return "Order Update Successful";
        }
    }
}

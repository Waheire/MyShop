using Microsoft.EntityFrameworkCore;
using MyShop.Data;
using MyShop.Models;
using MyShop.Models.Dtos;
using MyShop.Services.IServices;

namespace MyShop.Services
{
    public class ProductService : IProduct
    {
        private readonly AppDbContext _context;
       
        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddProductAsync(Product product)
        {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return "Product Added Successfully!";  
        }

        public async Task<string> DeleteProductAsync(Product product)
        {
                _context.Remove(product);
                await _context.SaveChangesAsync();
                return "Product Successfully Deleted!";
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
                return await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
        }

        public async Task<List<Product>> GetProductsAsync()
        {
                var products = await _context.Products.ToListAsync();
                return products;
        }

        public async Task<string> UpdateProductAsync( Product product)
        {
                _context.Update(product);
                await _context.SaveChangesAsync();
                return "Product Successfully Updated!";
        }
    }
}

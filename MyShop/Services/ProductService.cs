using Microsoft.EntityFrameworkCore;
using MyShop.Data;
using MyShop.Dtos;
using MyShop.Models;
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
        public async Task<string> AddProductAsync(AddProduct newProduct)
        {
            try 
            {
                _context.Add(newProduct);
                await _context.SaveChangesAsync();
                return "Product Added Successfully!";
            } catch (Exception ex)
            {
                return $"An Error Occurred! \n  {ex.Message}";
            }
           
        }

        public async Task<string> DeleteProductAsync(AddProduct Product)
        {
            try 
            {
                _context.Remove(Product);
                await _context.SaveChangesAsync();
                return "Product Successfully Deleted!";
            } catch (Exception ex)
            {
                return $"An Error occurred! {ex.Message}";
            }
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            try 
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
                return product;
            } catch (Exception ex) 
            {
                return new Product();
            }
          
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            try 
            {
                var products = await _context.Products.ToListAsync();
                return products;
            } catch (Exception ex) 
            {
                return new List<Product>();
            }
        }

        public async Task<string> UpdateProductAsync(Guid id, AddProduct updatedProduct)
        {
            try 
            {
                _context.Update(updatedProduct);
                await _context.SaveChangesAsync();
                return "Product Successfully Updated!";
            } catch (Exception ex) 
            {
                return $"An error Occurred! {ex.Message}";
            }
        }
    }
}

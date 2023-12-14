using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Models;
using MyShop.Models.Dtos;
using MyShop.Services.IServices;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProduct _productService;

        public ProductController(IMapper mapper, IProduct product)
        {
            _mapper = mapper;
            _productService = product;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            try 
            {
                var products = await _productService.GetProductsAsync();
                if (products == null) 
                {
                    return NotFound();
                }
                return Ok(products);
            } catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(Guid id) 
        {
            try 
            {
                var product = await _productService.GetProductByIdAsync(id);
                if (product == null) 
                {
                    return NotFound("Product Not Found");
                } 
                return Ok(product);
            } catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(AddProductDto productDto) 
        {
            try 
            {
                var product = _mapper.Map<Product>(productDto);
                var response = await _productService.AddProductAsync(product);
                return Created($"", response);

            } catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateProduct(Guid id, AddProductDto updateProduct)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                if (product == null)
                {
                    return NotFound("Product Not Found");
                }
                var updatedProduct = _mapper.Map(updateProduct, product);
                var response = await _productService.UpdateProductAsync(updatedProduct);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteProduct(Guid id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                if (product == null)
                {
                    return NotFound("Product Not Found");
                }
                var response = await _productService.DeleteProductAsync(product);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





    }
}

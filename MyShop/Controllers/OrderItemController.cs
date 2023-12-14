using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Models;
using MyShop.Models.Dtos;
using MyShop.Services;
using MyShop.Services.IServices;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItem _orderItemService;
        private readonly IMapper _mapper;

        public OrderItemController(IOrderItem orderItemService, IMapper mapper)
        {
            _mapper = mapper;
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderItem>>> GetAllOrderItems()
        {
            try
            {
                var orderItems = await _orderItemService.GetOrderItemsAsync();
                if (orderItems == null)
                {
                    return NotFound("Order Items Not Found");
                }
                return Ok(orderItems);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> GetOrderItemById(Guid id)
        {
            try
            {
                var orderItem = await _orderItemService.GetOrderItemByIdAsync(id);
                if (orderItem == null)
                {
                    return NotFound("Order Item Not Found");
                }
                return Ok(orderItem);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddOrderItem(AddOrderItemDto orderitem) 
        {
            try 
            {
                var newOrderItem = _mapper.Map<OrderItem>(orderitem);
                var response = await _orderItemService.AddOrderItemAsync(newOrderItem);
                return Created($"", response);

            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateOrderItem(Guid id, AddOrderItemDto updateOrderItem) 
        {
            try 
            {
                var orderItem = await _orderItemService.GetOrderItemByIdAsync(id);
                if (orderItem == null)
                {
                    return NotFound("Order Item Not Found");
                }
                var updatedOrderItem = _mapper.Map(updateOrderItem, orderItem);
                var response = await _orderItemService.UpdateOrderItemAsync(updatedOrderItem);
                return Ok(response);
            } catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteOrderItem(Guid id) 
        {
            try 
            {
                var orderItem = await _orderItemService.GetOrderItemByIdAsync(id);
                if (orderItem == null)
                {
                    return NotFound("Order Item Not Found");
                }
                var response = await _orderItemService.DeleteOrderItemAsync(orderItem);
                return Ok(response);

            } catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

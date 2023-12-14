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
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrder _orderService;

        public OrderController(IMapper mapper, IOrder orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderResponseDto>>> GetAllOrders() 
        {
            try 
            {
                var response = await _orderService.GetOrdersAsync();
                if (response == null) 
                {
                    return NotFound("Order Not Found");
                }
                var orders = _mapper.Map<List<OrderResponseDto>>(response);
                return Ok(orders);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(Guid id) 
        {
            try 
            {
                var order = await _orderService.GetOrderByIdAsync(id);
                if (order == null) 
                {
                    return NotFound("Order Not Found");
                }
                return Ok(order);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddOrder(AddOrderDto order) 
        {
            try 
            {
                var newOrder = _mapper.Map<Order>(order);
                var response = await _orderService.AddOrderAsync(newOrder);
                return Ok(response);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        //for admin
        public async Task<ActionResult<string>> UpdateOrder(Guid id, AddOrderDto updateOrder) 
        {
            try 
            {
                var order = await _orderService.GetOrderByIdAsync(id);
                if (order == null)
                {
                    return NotFound("Order Not Found");
                }
                var updatedOrder = _mapper.Map(updateOrder, order);
                var response = await _orderService.UpdateOrderAsync(updatedOrder);
                return Ok(response);
            } catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(Guid id) 
        {
            try 
            {
                var order = await _orderService.GetOrderByIdAsync(id);
                if (order == null)
                {
                    return NotFound("Order Not Found");
                }
                var response = _orderService.DeleteOrderAsync(order);
                return Ok(response);
                

            } catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

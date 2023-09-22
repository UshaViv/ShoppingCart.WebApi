using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Domain.Models;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("api/orders")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderAsync(int orderId)
        {
            if (orderId == 0)
            {
                return BadRequest("Order Id must be value");
            }

            var order = await _orderService.GetByIdAsync(orderId);
            return Ok(order);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync(int page = 1, int pageSize = 10)
        {
            var ordersPage = await _orderService.GetOrdersPageAsync(page, pageSize);
            return Ok(ordersPage);
        }

        [HttpPost]
        public IActionResult PlaceOrderAsync(Order order)
        {
            var success = _orderService.PlaceOrdersInQueue(order);

            if (success) { 
                return Ok("Order placed successfully");
            }else{
                return BadRequest("Failed to place an order");
            }
        }
    }
}

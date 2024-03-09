using ArtHub.DAO.ModelResult;
using ArtHub.DAO.OrderDTO;
using ArtHub.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ArtHub.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders([FromQuery] QueryPaging queryPaging)
        {
            var orders = await _orderService.GetAllOrders(queryPaging);
            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            var order = await _orderService.GetOrderById(orderId);
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrder createOrder)
        {
            var newOrder = await _orderService.CreateOrder(createOrder);
            return CreatedAtAction(nameof(GetOrderById), new { orderId = newOrder.Id }, newOrder);
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DisableOrder(int orderId)
        {
            await _orderService.DisableOrder(orderId);
            return NoContent();
        }
    }
}

﻿using ArtHub.DTO.OrderDTO;
using ArtHub.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ArtHub.API.Controllers
{
    [Route("order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrder creating)
        {
            var newOrder = await _orderService.CreateOrder(creating);
            return CreatedAtAction(nameof(GetOrderById), new { orderId = newOrder.OrderId }, newOrder);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById([FromRoute] int orderId)
        {
            var order = await _orderService.GetOrderById(orderId);
            if (order == null)
                return NotFound();

            return Ok(order);
        }
    }
}
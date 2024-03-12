using ArtHub.BusinessObject;
using ArtHub.DTO.OrderDTO;
using ArtHub.Repository.Contracts;
using ArtHub.Service.Contracts;
using AutoMapper;

namespace ArtHub.Service
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<ViewOrder> CreateOrder(CreateOrder order)
        {
            var orderDetails = _mapper.Map<List<OrderDetail>>(order.OrderDetails);
            var creating = new Order
            {
                BuyerId = order.BuyerId,
                TotalQuantity = order.TotalQuantity,
                TotalAmount = order.TotalAmount,
                OrderDate = DateTime.Now,
                OrderDetails = orderDetails
            };

            var result = await _orderRepository.CreateOrderAsync(creating);
            return _mapper.Map<ViewOrder>(result);
        }

        public async Task<ViewOrder?> GetOrderById(int id)
        {
            var result = await _orderRepository.GetOrderByIdAsync(id);
            if (result is null) return null;
            result.OrderDetails = await _orderRepository.GetOrderDetailsByOrderIdAsync(id);
            return _mapper.Map<ViewOrder>(result);
        }

        public Task<IEnumerable<Order>> GetOrderByMemberId(int id)
        {
            throw new NotImplementedException();
        }
    }
}

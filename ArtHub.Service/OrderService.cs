using ArtHub.BusinessObject;
using ArtHub.DAO.ModelResult;
using ArtHub.DAO.OrderDTO;
using ArtHub.Repository.Contracts;
using ArtHub.Service.Contracts;
using AutoMapper;

namespace ArtHub.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(
            IOrderRepository orderRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<Order> CreateOrder(CreateOrder createOrder)
        {
            var order = _mapper.Map<Order>(createOrder);
            order.OrderDate = DateTime.Now;
            order.TotalQuantity = 0;
            order.TotalAmount = 0; 
            return await _orderRepository.CreateOrder(order);
        }

        public async Task DisableOrder(int orderId)
        {
            await _orderRepository.DisableOrder(orderId);
        }

        public async Task<PagedResult<Order>> GetAllOrders(QueryPaging queryPaging)
        {
            queryPaging.Page = queryPaging.Page > 0 ? queryPaging.Page : 1;
            queryPaging.PageSize = queryPaging.PageSize > 0 ? queryPaging.PageSize : 10;
            queryPaging.Query = queryPaging.Query ?? string.Empty;
            return await _orderRepository.GetAllOrders(queryPaging.Page, queryPaging.PageSize);
        }

        public async Task<Order?> GetOrderById(int orderId)
        {
            return await _orderRepository.GetOrderById(orderId);
        }
    }
}

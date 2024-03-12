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
        private readonly IAccountRepository _accountRepository;
        private readonly IArtworkRepository _artworkRepository;

        public OrderService(IMapper mapper, IOrderRepository orderRepository, IAccountRepository accountRepository, IArtworkRepository artworkRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _accountRepository = accountRepository;
            _artworkRepository = artworkRepository;
        }

        public async Task<ViewOrder> CreateOrder(CreateOrder order)
        {
            var totalAmount = await _artworkRepository
                .GetTotalPriceByArtworkIds(order.OrderDetails.Select(od => od.ArtworkId).ToArray());

            if (totalAmount != order.TotalAmount) throw new Exception("Total amount is not correct");

            var userBalance = await _accountRepository.GetBalanceByAccountId(order.BuyerId);

            if (userBalance < totalAmount) throw new Exception("Not enough balance");

            foreach (var artwork in order.OrderDetails)
            {
                var hasBuyArtwork = await _orderRepository.MemberHasBuyArtwork(artwork.ArtworkId, order.BuyerId);
                if (hasBuyArtwork)
                    throw new Exception("You have already bought artwork has id: " + artwork.ArtworkId);
            }

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
            foreach (var od in result.OrderDetails)
            {
                await _accountRepository.UpdateBalanceAccountForSell(od.ArtworkId, od.UnitPrice);
            }

            var amountAfterBuy = userBalance - totalAmount;
            await _accountRepository.UpdateBalanceByAccountId(order.BuyerId, amountAfterBuy);
            return _mapper.Map<ViewOrder>(result);
        }

        public async Task<ViewOrder?> GetOrderById(int id)
        {
            var result = await _orderRepository.GetOrderByIdAsync(id);
            if (result is null) return null;
            //result.OrderDetails = await _orderRepository.GetOrderDetailsByOrderIdAsync(id);
            return _mapper.Map<ViewOrder>(result);
        }

        public Task<IEnumerable<Order>> GetOrderByMemberId(int id)
        {
            throw new NotImplementedException();
        }
    }
}

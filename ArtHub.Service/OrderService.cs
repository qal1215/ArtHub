using ArtHub.BusinessObject;
using ArtHub.DTO.BalanceDTO;
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
        private readonly IBalanceService _balanceService;

        public OrderService(IMapper mapper, IOrderRepository orderRepository, IAccountRepository accountRepository, IArtworkRepository artworkRepository, IBalanceService balanceService)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _accountRepository = accountRepository;
            _artworkRepository = artworkRepository;
            _balanceService = balanceService;
        }

        public async Task<ResultViewOrder> CreateOrder(CreateOrder order)
        {
            var totalAmount = await _artworkRepository
                .GetTotalPriceByArtworkIds(order.OrderDetails.Select(od => od.ArtworkId).ToArray());

            if (totalAmount != order.TotalAmount)
            {
                return new ResultViewOrder
                {
                    OrderStatus = OrderStatus.Failed,
                    Message = "Total amount is not correct"
                };
            }

            var userBalance = await _accountRepository.GetBalanceByAccountId(order.BuyerId);

            if (userBalance < totalAmount)
            {
                return new ResultViewOrder
                {
                    OrderStatus = OrderStatus.Failed,
                    Message = "Balance not enough money!"
                };
            }

            foreach (var artwork in order.OrderDetails)
            {
                var hasBuyArtwork = await _orderRepository.MemberHasBuyArtwork(artwork.ArtworkId, order.BuyerId);
                if (hasBuyArtwork)
                {
                    return new ResultViewOrder
                    {
                        OrderStatus = OrderStatus.Failed,
                        Message = "You have already bought artwork has id: " + artwork.ArtworkId
                    };
                }

                var isBuyable = await _artworkRepository.IsBuyAvailable(artwork.ArtworkId);
                if (!isBuyable)
                {
                    return new ResultViewOrder
                    {
                        OrderStatus = OrderStatus.Failed,
                        Message = "Artwork has id: " + artwork.ArtworkId + " is not available for sell"
                    };
                }
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
                var artistId = await _artworkRepository.GetArtistIdByArtworkId(od.ArtworkId);
                var transactionAmount = new TransactionAmount
                {
                    AccountId = artistId,
                    Amount = od.UnitPrice
                };
                await _balanceService.SellBalanceAsync(transactionAmount, od.ArtworkId);

                var purchaseAmount = new TransactionAmount
                {
                    AccountId = order.BuyerId,
                    Amount = od.UnitPrice
                };
                await _balanceService.PurchaseArtworkAsync(purchaseAmount, od.ArtworkId);
            }

            var viewOrder = _mapper.Map<ViewOrder>(result);

            return new ResultViewOrder
            {
                OrderStatus = OrderStatus.Success,
                ViewOrder = viewOrder
            };
        }

        public async Task<ViewOrder?> GetOrderById(int id)
        {
            var result = await _orderRepository.GetOrderByIdAsync(id);
            if (result is null) return null;
            //result.OrderDetails = await _orderRepository.GetOrderDetailsByOrderIdAsync(id);
            return _mapper.Map<ViewOrder>(result);
        }

        public async Task<IEnumerable<ViewOrder>> GetOrdersByMemberId(int id)
        {
            var result = await _orderRepository.GetOrdersByBuyerIdAsync(id);
            return _mapper.Map<IEnumerable<ViewOrder>>(result);
        }
    }
}

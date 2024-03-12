using ArtHub.BusinessObject;
using ArtHub.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ArtHub.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ArtHub2024DbContext _dbContext;

        public OrderRepository(ArtHub2024DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> MemberHasBuyArtwork(int artworkId, int buyerId)
        {
            var hasBuyArtwork = await _dbContext.OrderDetails
                .AnyAsync(od => od.ArtworkId == artworkId && od.Order.BuyerId == buyerId);
            return hasBuyArtwork;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<OrderDetail>> CreateOrderDetailAsync(IEnumerable<OrderDetail> orderDetails)
        {
            await _dbContext.OrderDetails.AddRangeAsync(orderDetails);
            return orderDetails;
        }

        public Task<Order> DeleteOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Order?> GetOrderByIdAsync(int orderId)
        {
            return await _dbContext.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
            return await _dbContext.OrderDetails
                .Where(od => od.OrderDetailId == orderId)
                .ToListAsync();
        }

        public Task<IEnumerable<Order>> GetOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangeAsync() => await _dbContext.SaveChangesAsync();

        public async Task<IEnumerable<Order>> GetOrdersByBuyerIdAsync(int memberId)
        {
            return await _dbContext.Orders
                .Include(o => o.OrderDetails)
                .Where(o => o.BuyerId == memberId)
                .ToListAsync();
        }
    }
}

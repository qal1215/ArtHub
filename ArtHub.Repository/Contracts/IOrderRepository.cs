using ArtHub.BusinessObject;

namespace ArtHub.Repository.Contracts
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersAsync();

        Task<Order?> GetOrderByIdAsync(int id);

        Task<Order> CreateOrderAsync(Order order);

        Task<Order> UpdateOrderAsync(Order order);

        Task<Order> DeleteOrderAsync(int id);

        Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId);
        Task<IEnumerable<OrderDetail>> CreateOrderDetailAsync(IEnumerable<OrderDetail> orderDetails);
        Task SaveChangeAsync();
        Task<bool> MemberHasBuyArtwork(int artworkId, int buyerId);
    }
}

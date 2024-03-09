using ArtHub.BusinessObject;
using ArtHub.DAO.ModelResult;

namespace ArtHub.Repository.Contracts
{
    public interface IOrderRepository
    {
        public Task<PagedResult<Order>> GetAllOrders(int page, int pageSize);
        public Task<Order?> GetOrderById(int orderId);
        public Task<Order> CreateOrder(Order order);
        public Task DisableOrder(int orderId);
    }
}

using ArtHub.BusinessObject;
using ArtHub.DAO.ModelResult;
using ArtHub.DAO.OrderDTO;

namespace ArtHub.Service.Contracts
{
    public interface IOrderService
    {
        public Task<PagedResult<Order>> GetAllOrders(QueryPaging queryPaging);
        public Task<Order?> GetOrderById(int orderId);
        public Task<Order> CreateOrder(CreateOrder createOrder);
        public Task DisableOrder(int orderId);
    }
}

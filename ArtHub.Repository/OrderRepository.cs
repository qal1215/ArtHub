using ArtHub.BusinessObject;
using ArtHub.DAO;
using ArtHub.DAO.ModelResult;
using ArtHub.Repository.Contracts;

namespace ArtHub.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public async Task<Order> CreateOrder(Order order)
        {
            return await OrderDAO.Instance.CreateOrder(order);
        }

        public async Task DisableOrder(int orderId)
        {
            await OrderDAO.Instance.DisableOrder(orderId);
        }

        public async Task<PagedResult<Order>> GetAllOrders(int page, int pageSize)
        {
            return await OrderDAO.Instance.GetAllOrders(page, pageSize);
        }

        public Task<Order?> GetOrderById(int orderId)
        {
            return OrderDAO.Instance.GetOrderById(orderId);
        }
    }
}

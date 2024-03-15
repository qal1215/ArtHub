using ArtHub.DTO.OrderDTO;

namespace ArtHub.Service.Contracts
{
    public interface IOrderService
    {
        Task<ResultViewOrder> CreateOrder(CreateOrder order);
        Task<ViewOrder?> GetOrderById(int id);
        Task<IEnumerable<ViewOrder>> GetOrdersByMemberId(int id);
    }
}

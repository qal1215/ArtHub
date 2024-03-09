using ArtHub.BusinessObject;
using ArtHub.DAO.ModelResult;
using Microsoft.EntityFrameworkCore;

namespace ArtHub.DAO
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private readonly ArtHub2024DbContext dbContext = null;
        public OrderDAO()
        {
            if (dbContext == null)
            {
                dbContext = new ArtHub2024DbContext();
            }
        }

        public static OrderDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDAO();
                }
                return instance;
            }
        }

        public async Task<PagedResult<Order>> GetAllOrders(int page, int pageSize)
        {
            var orders = await dbContext.Orders           
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var totalItems = await dbContext.Orders
                .CountAsync();
            decimal totalPages = (decimal)totalItems / pageSize;

            return new PagedResult<Order>
            {
                Page = page,
                PageSize = pageSize,
                TotalPages = (int)Math.Round(totalPages),
                TotalItems = totalItems,
                Items = orders
            };
        }

        public async Task<Order?> GetOrderById(int orderId)
        {
            return await dbContext.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<Order> CreateOrder(Order order)
        {
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
            return order;
        }

        public async Task DisableOrder(int orderId)
        {
            var order = await dbContext.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
            if (order is not null)
            {
                dbContext.Orders.Remove(order);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}

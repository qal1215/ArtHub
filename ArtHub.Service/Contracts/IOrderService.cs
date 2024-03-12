﻿using ArtHub.BusinessObject;
using ArtHub.DTO.OrderDTO;

namespace ArtHub.Service.Contracts
{
    public interface IOrderService
    {
        Task<ViewOrder> CreateOrder(CreateOrder order);

        Task<ViewOrder?> GetOrderById(int id);

        Task<IEnumerable<Order>> GetOrderByMemberId(int id);
    }
}
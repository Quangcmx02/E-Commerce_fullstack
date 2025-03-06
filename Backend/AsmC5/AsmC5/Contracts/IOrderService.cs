using AsmC5.Common.Request;
using AsmC5.DTOs.OrderDtos;
using AsmC5.Models;

namespace AsmC5.Contracts
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetOrdersByDateRangeAsync(
            DateTime startDate,
            DateTime endDate);

        Task<IEnumerable<OrderDto>> GetRecentOrdersAsync(int count);
        Task<Dictionary<OrderStatus, int>> GetOrderStatusStatisticsAsync();
        Task<(IEnumerable<OrderDto> orders, MetaData metaData)> GetAllOrdersAsync(OrderRequestParameters parameters);

        Task<IEnumerable<OrderDto>> GetOrdersByUserIdAsync(string userId,
            OrderForUserRequestParameters orderForUserRequestParameters);

        Task<OrderDto> GetOrderByIdAsync(int orderId);
        Task<OrderDto> UpdateOrderStatusAsync(int orderId, OrderStatus status);
    }
}

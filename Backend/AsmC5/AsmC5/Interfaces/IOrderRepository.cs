using AsmC5.Common.Request;
using AsmC5.Models;

namespace AsmC5.Interfaces
{
    public interface IOrderRepository: IRepositoryBase<Order>
    {
        
        Task<Order?> GetOrderByIdWithDetailsAsync(int orderId, bool asNoTracking = false);
        Task<bool> OrderExistsAsync(int orderId);
     
        Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status, bool asNoTracking = false);
        Task<int> GetTotalOrdersCountAsync();
        Task<Dictionary<OrderStatus, int>> GetOrderStatusStatisticsAsync();
        Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus);
        Task<IEnumerable<Order>> GetRecentOrdersAsync(int count, bool asNoTracking = false);
        Task<IEnumerable<Order>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate, bool asNoTracking = false);
        Task<decimal> CalculateTotalAmountAsync(int orderId);
        Task<PagedList<Order>> FetchAllOrderAsync(OrderRequestParameters orderRequestParameters);
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId, OrderForUserRequestParameters orderForUserRequestParameters);
    }
}

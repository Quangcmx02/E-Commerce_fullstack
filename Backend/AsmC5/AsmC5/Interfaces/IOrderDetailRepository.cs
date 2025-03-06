using AsmC5.Models;
using System.Linq.Expressions;

namespace AsmC5.Interfaces
{
    public interface IOrderDetailRepository : IRepositoryBase<OrderDetail>
    {
        Task<IEnumerable<OrderDetail>> GetOrderDetailsWithRelationsAsync(
            Expression<Func<OrderDetail, bool>>? filter = null,
            bool asNoTracking = false);

        Task<bool> IsOrderDetailExistAsync(int id);
        Task<decimal> GetTotalPriceByOrderIdAsync(int orderId);
        Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId, bool asNoTracking = false);
        Task<OrderDetail?> GetOrderDetailByIdWithRelationsAsync(int id, bool asNoTracking = false);
    }
}

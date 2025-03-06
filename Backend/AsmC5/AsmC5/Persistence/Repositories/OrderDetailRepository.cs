using System.Linq.Expressions;
using AsmC5.Context;
using AsmC5.Interfaces;
using AsmC5.Models;
using Microsoft.EntityFrameworkCore;

namespace AsmC5.Persistence.Repositories
{
    public class OrderDetailRepository:RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<OrderDetail?> GetOrderDetailByIdWithRelationsAsync(int id, bool asNoTracking = false)
        {
            IQueryable<OrderDetail> query = _dbSet
                        .Include(od => od.Order)
                        .Include(od => od.FoodItem)
                        .Include(od => od.Order)
                        .Include(od => od.Combo)
                        .ThenInclude(od => od.ComboFoodItems)
                        .ThenInclude(od => od.ComboFoodItemDetails)
                    ;

                if (asNoTracking)
                    query = query.AsNoTracking();

                return await query.FirstOrDefaultAsync(od => od.OrderID == id);
            
        }
        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId, bool asNoTracking = false)
        {
            IQueryable<OrderDetail> query = _dbSet
                .Include(od => od.FoodItem)
                .Include(od => od.Combo)
                .ThenInclude(od => od.ComboFoodItems)
                .ThenInclude(od => od.ComboFoodItemDetails)
                .Where(od => od.OrderID == orderId);

            if (asNoTracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<decimal> GetTotalPriceByOrderIdAsync(int orderId)
        {
            return await _dbSet
                .Where(od => od.OrderID == orderId)
                .SumAsync(od => od.Price * ((od.QuantityFoodItem ?? 0) + (od.QuantityCombo ?? 0)));
        }
        public async Task<bool> IsOrderDetailExistAsync(int id)
        {
            return await _dbSet.AnyAsync(od => od.OrderDetailID == id);
        }
        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsWithRelationsAsync(
            Expression<Func<OrderDetail, bool>>? filter = null,
            bool asNoTracking = false)
        {
            IQueryable<OrderDetail> query = _dbSet
                    .Include(od => od.Order)
                    .Include(od => od.FoodItem)
                    .Include(od => od.Order)
                    .Include(od => od.Combo)
                    .ThenInclude(od => od.ComboFoodItems)
                    .ThenInclude(od => od.ComboFoodItemDetails)
                ;

            if (filter != null)
                query = query.Where(filter);

            if (asNoTracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }
    }
}

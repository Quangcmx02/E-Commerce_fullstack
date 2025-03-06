using AsmC5.Common.Request;
using AsmC5.Context;
using AsmC5.Interfaces;
using AsmC5.Models;
using Microsoft.EntityFrameworkCore;

namespace AsmC5.Persistence.Repositories
{
    public class OrderRepository :RepositoryBase<Order> ,IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        private IQueryable<Order> ApplyOrdering(IQueryable<Order> query, string orderBy)
            {
                switch (orderBy.ToLower())
                {
                    case "newest":
                        query = query.OrderByDescending(o => o.OrderTime);
                        break;
                    case "oldest":
                        query = query.OrderBy(o => o.OrderTime);
                        break;
                    case "lowest-price":
                        query = query.OrderBy(o => o.TotalAmount);
                        break;
                    case "highest-price":
                        query = query.OrderByDescending(o => o.TotalAmount);
                        break;
                    case "most-items":
                        query = query.OrderByDescending(o => o.OrderDetails.Count);
                        break;
                    case "fewest-items":
                        query = query.OrderBy(o => o.OrderDetails.Count);
                        break;
                    default:
                        query = query.OrderBy(o => o.OrderID);
                        break;
                }
                return query;
            }

    
        public async Task<PagedList<Order>> FetchAllOrderAsync(OrderRequestParameters orderRequestParameters)
        {
            var query = _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(pvv => pvv.FoodItem)
                . Include(pvv => pvv.OrderDetails)
                .ThenInclude(pvv => pvv.Combo)
                .Include(o => o.User)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(orderRequestParameters.SearchTerm))
            {
                var searchTerm = orderRequestParameters.SearchTerm.Trim().ToLower();
                query = query.Where(o => o.OrderDetails.Any(od => od.FoodItem!=null&& od.FoodItem.Name.ToLower().Contains(searchTerm) ||
                                                                  (od.Combo != null && od.Combo.Name.ToLower().Contains(searchTerm))));
            }

            if (!string.IsNullOrWhiteSpace(orderRequestParameters.OrderBy))
            {
                query = ApplyOrdering(query, orderRequestParameters.OrderBy);
            }

            if (orderRequestParameters.OrderStatus.HasValue)
            {
                query = query.Where(order => order.Status == orderRequestParameters.OrderStatus);
            }

            if (orderRequestParameters.FormDate.HasValue)
            {
                var fromDate = orderRequestParameters.FormDate.Value.Date;
                query = query.Where(o => o.OrderTime >= fromDate);
            }

            if (orderRequestParameters.ToDate.HasValue)
            {
                var toDate = orderRequestParameters.ToDate.Value.Date.AddDays(1); 
                query = query.Where(o => o.OrderTime < toDate);
            }

            if (!string.IsNullOrWhiteSpace(orderRequestParameters.OrderBy))
            {
                query = ApplyOrdering(query, orderRequestParameters.OrderBy);
            }

            var totalCount = await query.CountAsync();


            var items = await query
                .Skip((orderRequestParameters.PageNumber - 1) * orderRequestParameters.PageSize)
                .Take(orderRequestParameters.PageSize)
                .ToListAsync();

            return new PagedList<Order>(items, totalCount, orderRequestParameters.PageNumber, orderRequestParameters.PageSize);
        }
        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId, OrderForUserRequestParameters orderForUserRequestParameters)
        {
            var query = _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(pvv => pvv.FoodItem)
                .Include(pvv => pvv.OrderDetails)
                .ThenInclude(pvv => pvv.Combo)
                .Include(o => o.User)
                .Where(o => o.UserID== userId)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(orderForUserRequestParameters.SearchTerm))
            {
                var searchTerm = orderForUserRequestParameters.SearchTerm.Trim().ToLower();
                query = query.Where(o => o.OrderDetails.Any(od => od.FoodItem != null && od.FoodItem.Name.ToLower().Contains(searchTerm) ||
                                                                  (od.Combo != null && od.Combo.Name.ToLower().Contains(searchTerm))));
            }

            if (!string.IsNullOrWhiteSpace(orderForUserRequestParameters.OrderBy))
            {
                query = ApplyOrdering(query, orderForUserRequestParameters.OrderBy);
            }

            return await query.ToListAsync();
        }
        public async Task<Order?> GetOrderByIdWithDetailsAsync(int orderId, bool asNoTracking = false)
        {
            var query = _context.Orders
                .Include(o => o.OrderDetails)  // Chỉ cần Include 1 lần
                .ThenInclude(od => od.FoodItem)
                .Include(o => o.OrderDetails)  // Tiếp tục Include Combo trong OrderDetails
                .ThenInclude(od => od.Combo)
                .Include(o => o.User)
                .Where(o => o.OrderID == orderId);


            return asNoTracking
                ? await query.AsNoTracking().FirstOrDefaultAsync()
                : await query.FirstOrDefaultAsync();
        }
        public async Task<bool> OrderExistsAsync(int orderId)
        {
            return await _context.Orders.AnyAsync(o => o.OrderID == orderId);
        }
        //public async Task<decimal> GetTotalOrderAmountByUserIdAsync(string userId)
        //{
        //    return await _context.Orders
        //        .Where(o => o.UserID == userId)
        //        .SumAsync(o => o.);
        //}
        public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status, bool asNoTracking = false)
        {
            var query = _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                .Where(o => o.Status == status);

            return asNoTracking
                ? await query.AsNoTracking().ToListAsync()
                : await query.ToListAsync();
        }
        public async Task<int> GetTotalOrdersCountAsync()
        {
            return await _context.Orders.CountAsync();
        }
        public async Task<Dictionary<OrderStatus, int>> GetOrderStatusStatisticsAsync()
        {
            return await _context.Orders
                .GroupBy(o => o.Status)
                .ToDictionaryAsync(
                    g => g.Key,
                    g => g.Count()
                );
        }
        public async Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                order.Status = newStatus;
                _context.Entry(order).Property(x => x.OrderTime).IsModified = false; //h
                _context.Orders.Update(order);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Order>> GetRecentOrdersAsync(int count, bool asNoTracking = false)
        {
            var query = _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                .OrderByDescending(o => o.OrderTime)
                .Take(count);

            return asNoTracking
                ? await query.AsNoTracking().ToListAsync()
                : await query.ToListAsync();
        }
        public async Task<IEnumerable<Order>> GetOrdersByDateRangeAsync(
            DateTime startDate,
            DateTime endDate,
            bool asNoTracking = false)
        {
            var query = _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                .Where(o => o.OrderTime >= startDate && o.OrderTime <= endDate);

            return asNoTracking
                ? await query.AsNoTracking().ToListAsync()
                : await query.ToListAsync();
        }
        public async Task<decimal> CalculateTotalAmountAsync(int orderId)
        {
            var totalAmount = await _dbSet
                .Where(o => o.OrderID == orderId)
                .Select(o => o.OrderDetails.Sum(od => od.Price * ((od.QuantityFoodItem ?? 0) + (od.QuantityCombo ?? 0))))
                .FirstOrDefaultAsync();

            return totalAmount;
        }

    }
}

using AsmC5.Common.Request;
using AsmC5.Context;
using AsmC5.Interfaces;
using AsmC5.Models;
using Microsoft.EntityFrameworkCore;

namespace AsmC5.Persistence.Repositories
{
    public class CartRepository : RepositoryBase<Cart>, ICartRepository
    {
        public CartRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<int> GetTotalCartProductsForUser(string userId)
        {
            var cart = await _dbSet
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserID == userId);

            // Nếu user chưa có giỏ hàng thì tạo mới
            if (cart == null)
            {
                cart = new Cart { UserID = userId };
                await _dbSet.AddAsync(cart);
                await _context.SaveChangesAsync();
                return 0;
            }

            return cart.CartItems.Count;
        }
        public async Task<bool> IsCartExistsAsync(string sessionId)
        {
            return await _dbSet.AnyAsync(c => c.SessionId == sessionId);
        }
        public async Task<Cart> EnsureCartExistsForUserAsync(string userId)
        {
            var existingCart = await _dbSet.FirstOrDefaultAsync(c => c.UserID == userId);

            if (existingCart != null)
            {
                return existingCart; // Trả về giỏ hàng hiện có
            }

            var newCart = new Cart { UserID = userId };
            await _dbSet.AddAsync(newCart);
            await _context.SaveChangesAsync();

            return newCart;
        }
        public async Task<Cart?> GetCartByUserIdAsync(string userId)
        {
            IQueryable<Cart> query = _dbSet;

                query = query // Bỏ "var" để tiếp tục sử dụng query
                    .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.FoodItem) // Nếu CartItem chứa FoodItem

                    .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.Combo) // Nếu CartItem chứa Combo
                    .ThenInclude(c => c.ComboFoodItems) // Lấy danh sách ComboFoodItem
                    .ThenInclude(cfi => cfi.FoodItem) // Lấy FoodItem trong Combo

                    .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.Combo)
                    .ThenInclude(c => c.ComboFoodItems) // Tiếp tục lấy thông tin chi tiết
                    .ThenInclude(cfi => cfi.ComboFoodItemDetails) // Lấy số lượng FoodItem trong Combo

                    .Include(c => c.User) // Bao gồm thông tin User
                    .AsNoTracking()
                    .AsQueryable();
            

            return await query.FirstOrDefaultAsync(c => c.UserID == userId);
        }
        public async Task<Cart> CreateCartForUserAsync(string userId)
        {
            var existingCart = await _dbSet.FirstOrDefaultAsync(c => c.UserID == userId);

            if (existingCart != null)
            {
                return existingCart; // Trả về giỏ hàng cũ nếu đã tồn tại
            }

            var newCart = new Cart { UserID = userId };
            await _dbSet.AddAsync(newCart);
            await _context.SaveChangesAsync();

            return newCart;
        }
        public async Task<PagedList<Cart>> FetchAllCartAsync(CartRequestParameters cartRequestParameters)
        {
            var query = _dbSet
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.FoodItem) // Nếu CartItem chứa FoodItem

                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Combo) // Nếu CartItem chứa Combo
                .ThenInclude(c => c.ComboFoodItems) // Lấy danh sách ComboFoodItem
                .ThenInclude(cfi => cfi.FoodItem) // Lấy FoodItem trong Combo

                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Combo)
                .ThenInclude(c => c.ComboFoodItems) // Tiếp tục lấy thông tin chi tiết
                .ThenInclude(cfi => cfi.ComboFoodItemDetails) // Lấy số lượng FoodItem trong Combo

                .Include(c => c.User) // Bao gồm thông tin User
                .AsNoTracking()
                .AsQueryable();



            if (!string.IsNullOrWhiteSpace(cartRequestParameters.SearchTerm))
            {
                query = query.Where(c => c.User.LastName.Contains(cartRequestParameters.SearchTerm)
                                         || c.User.FirstName.Contains(cartRequestParameters.SearchTerm)
                                         || c.User.Email.Contains(cartRequestParameters.SearchTerm)
                                         || c.User.UserName.Contains(cartRequestParameters.SearchTerm)
                );
            }

            if (!string.IsNullOrWhiteSpace(cartRequestParameters.OrderBy))
            {
                var orderKey = cartRequestParameters.OrderKey?.Trim().ToLower() ?? "";
                var orderBy = cartRequestParameters.OrderBy.Trim().ToLower();
                query = orderKey switch
                {
                    "created" => orderBy == "desc" ? query.OrderByDescending(b => b.CreatedAt) : query.OrderBy(b => b.CreatedAt),
                    _ => query.OrderBy(b => b.CartID),
                };

            }

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((cartRequestParameters.PageNumber - 1) * cartRequestParameters.PageSize)
                .Take(cartRequestParameters.PageSize)
                .ToListAsync();

            return new PagedList<Cart>(items, totalCount, cartRequestParameters.PageNumber, cartRequestParameters.PageSize);
        }
        public async Task<Cart?> GetCartBySessionIdAsync(string sessionId)
        {
            IQueryable<Cart> query = _dbSet; // Khai báo query lần đầu

            query = query // Bỏ "var" để tiếp tục sử dụng query
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.FoodItem) // Nếu CartItem chứa FoodItem

                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Combo) // Nếu CartItem chứa Combo
                .ThenInclude(c => c.ComboFoodItems) // Lấy danh sách ComboFoodItem
                .ThenInclude(cfi => cfi.FoodItem) // Lấy FoodItem trong Combo

                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Combo)
                .ThenInclude(c => c.ComboFoodItems) // Tiếp tục lấy thông tin chi tiết
                .ThenInclude(cfi => cfi.ComboFoodItemDetails) // Lấy số lượng FoodItem trong Combo

                .Include(c => c.User) // Bao gồm thông tin User
                .AsNoTracking()
                .AsQueryable();

            return await query.FirstOrDefaultAsync(c => c.SessionId == sessionId);
        }
        public async Task ClearCartAsync(int cartId)
        {
            var cart = await _dbSet
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.CartID == cartId);

            if (cart != null)
            {
                _context.RemoveRange(cart.CartItems);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateCartSessionAsync(int cartId, string newSessionId)
        {
            var cart = await _dbSet.FindAsync(cartId);
            if (cart != null)
            {
                cart.SessionId = newSessionId;
                await _context.SaveChangesAsync();
            }
        }
        public async Task<decimal> GetCartTotalAsync(int cartId)
        {
            return await _dbSet
                .Where(c => c.CartID == cartId)
                .SelectMany(c => c.CartItems)
                .SumAsync(ci =>
                    (ci.QuantityFoodItem.HasValue ? ci.QuantityFoodItem.Value : 0) * (ci.FoodItem != null ? ci.FoodItem.Price : 0) +
                    (ci.QuantityCombo.HasValue ? ci.QuantityCombo.Value : 0) * (ci.Combo != null ? ci.Combo.Price : 0)
                );
               
        }

    }
}

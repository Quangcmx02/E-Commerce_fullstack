using AsmC5.Common.Request;
using AsmC5.Models;

namespace AsmC5.Interfaces
{
    public interface ICartRepository : IRepositoryBase<Cart>
    {
        Task<bool> IsCartExistsAsync(string sessionId);
        Task<decimal> GetCartTotalAsync(int cartId);
        Task<int> GetTotalCartProductsForUser(string userId);
        Task<Cart> EnsureCartExistsForUserAsync(string userId);
        Task<Cart?> GetCartByUserIdAsync(string userId);
        Task<Cart> CreateCartForUserAsync(string userId);
        Task<PagedList<Cart>> FetchAllCartAsync(CartRequestParameters cartRequestParameters);
        Task<Cart?> GetCartBySessionIdAsync(string sessionId);
        Task ClearCartAsync(int cartId);
        Task UpdateCartSessionAsync(int cartId, string newSessionId);
    }
}

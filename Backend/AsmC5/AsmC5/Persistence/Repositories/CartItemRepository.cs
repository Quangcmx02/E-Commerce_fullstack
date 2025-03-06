using AsmC5.Context;
using AsmC5.Interfaces;
using AsmC5.Models;

namespace AsmC5.Persistence.Repositories
{
    public class CartItemRepository : RepositoryBase<CartItem>, ICartItemRepository
    {
        public CartItemRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

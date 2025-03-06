using AsmC5.Context;
using AsmC5.Interfaces;
using AsmC5.Models;

namespace AsmC5.Persistence.Repositories
{
    public class ComboFoodItemRepository:RepositoryBase<ComboFoodItem>, IComboFoodItemRepository
    {
        public ComboFoodItemRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

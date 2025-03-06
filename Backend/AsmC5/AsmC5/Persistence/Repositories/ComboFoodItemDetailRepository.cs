using AsmC5.Context;
using AsmC5.Interfaces;
using AsmC5.Models;

namespace AsmC5.Persistence.Repositories
{
    public class ComboFoodItemDetailRepository : RepositoryBase<ComboFoodItemDetail>, IComboFoodItemDetailRepository
    {
        public ComboFoodItemDetailRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

using AsmC5.Common.Request;
using AsmC5.Models;

namespace AsmC5.Interfaces
{
    public interface IFoodItemRepository : IRepositoryBase<FoodItem>
    {
        Task<FoodItem?> GetFoodItemByIdWithDetailsAsync(int id);
        Task<PagedList<FoodItem>> GetFoodItemWithDetailsAsync(FoodItemRequestParameters foodItemRequestParameters);
        Task<IEnumerable<FoodItem>> GetFoodItemByCategoryIdAsync(int categoryId);

        Task<bool> ProductExistsAsync(int id);
        Task<bool> ProductNameExistsAsync(string name);
    }
}

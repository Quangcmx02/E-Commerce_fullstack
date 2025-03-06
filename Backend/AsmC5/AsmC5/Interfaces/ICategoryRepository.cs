using AsmC5.Common.Request;
using AsmC5.Models;

namespace AsmC5.Interfaces
{
    public interface ICategoryRepository :IRepositoryBase<Category>
    {
        Task<bool> CategoryExistsByIdAsync(int categoryId);
        Task<bool> CategoryExistsAsync(string categoryName);
        Task<PagedList<Category>> FetchAllCategoriesWithPaging(CategoryRequestParameters categoryRequestParameters);
    }
}

using AsmC5.Common.Request;
using AsmC5.DTOs.CategoryDtos;

namespace AsmC5.Contracts
{
    public interface ICategoryService
    {
        Task<(IEnumerable<CategoryDto> categories, MetaData metaData)> GetAllCategoriesAsync(CategoryRequestParameters categoryRequestParameters);
        Task<CategoryDto> GetCategoryByIdAsync(int categoryId);
        Task CreateCategoryAsync(CategoryForCreateDto categoryForCreateDto);
        Task UpdateCategoryAsync(int categoryId, CategoryForUpdateDto categoryForUpdateDto);
        Task DeleteCategoryAsync(int categoryId);
        Task<bool> CategoryExistsAsync(string categoryName);
        Task<CategoryDto> GetCategoryByNameAsync(string categoryName);
      
    }
}

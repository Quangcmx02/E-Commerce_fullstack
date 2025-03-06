using AsmC5.Common.Request;
using AsmC5.DTOs.FoodItemDtos;

namespace AsmC5.Contracts
{
    public interface IFoodItemService
    {
        Task<(IEnumerable<FoodItemDto> foodItems, MetaData metaData)> GetAllFoodItemAsync(FoodItemRequestParameters foodItemRequestParameters);
        Task<FoodItemDto> GetFoodItemByIdAsync(int id);
        //Task<FoodItemDto> GetFoodItemBySlugNameAsync(string slugName);
        Task<IEnumerable<FoodItemDto>> GetFoodItemByCategoryIdAsync(int categoryId);

        Task<FoodItemDto> CreateProductAsync(FoodItemForCreateDto productDto);

        Task<FoodItemDto> UpdateProductAsync(int productId, FoodItemForUpdateDto productDto);
        //Task<FoodItemDto> CreateProductAsync(FoodItemForCreateDto foodItemDto);
        //Task<FoodItemDto> UpdateProductAsync(int foodItemId, FoodItemForUpdateDto productDto);
        Task DeleteProductAsync(int id);
        //Task<bool> ProductExistsAsync(int id);
        //Task UpdateProductQuantityAsync(int id, int quantity);
    }
}

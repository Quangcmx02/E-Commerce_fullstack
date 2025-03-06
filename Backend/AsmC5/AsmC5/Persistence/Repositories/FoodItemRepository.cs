using AsmC5.Common.Request;
using AsmC5.Context;
using AsmC5.Interfaces;
using AsmC5.Models;
using Microsoft.EntityFrameworkCore;

namespace AsmC5.Persistence.Repositories
{
    public class FoodItemRepository : RepositoryBase<FoodItem>, IFoodItemRepository
    {
        public FoodItemRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<FoodItem?> GetFoodItemByIdWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(p => p.Category)
               
                .FirstOrDefaultAsync(p => p.FoodItemId == id);
        }

        public async Task<PagedList<FoodItem>> GetFoodItemWithDetailsAsync(FoodItemRequestParameters foodItemRequestParameters)
        {
            var query = _dbSet
                .Include(p => p.Category)
                .AsNoTracking()
                .AsQueryable();

            Console.WriteLine("🔍 Initial Query: " + query.ToQueryString());

            // Search
            if (!string.IsNullOrWhiteSpace(foodItemRequestParameters.SearchTerm))
            {
                string searchTerm = foodItemRequestParameters.SearchTerm.Trim().ToLower();
                query = query.Where(p =>
                    p.Name != null && p.Name.ToLower().Contains(searchTerm) ||
                    p.Description != null && p.Description.ToLower().Contains(searchTerm) 
  
                );

                Console.WriteLine($"🔍 Search Term: {searchTerm}");
                Console.WriteLine("📌 Query after search filter: " + query.ToQueryString());
            }

            // Categories filter
            if (foodItemRequestParameters.Categories?.Any() == true)
            {
                Console.WriteLine("📌 Filtering by categories: " + string.Join(", ", foodItemRequestParameters.Categories));
                query = query.Where(p => p.Category != null &&
                    foodItemRequestParameters.Categories.Contains(p.Category.Name));

                Console.WriteLine("📌 Query after category filter: " + query.ToQueryString());
            }


            // Price range filter
            if (foodItemRequestParameters.PriceRange != null)
            {
                var priceList = foodItemRequestParameters.PriceRange.Split('-');
                int minPrice = int.Parse(priceList[0]);
                int maxPrice = int.Parse(priceList[1]);

                Console.WriteLine($"📌 Filtering by price range: {minPrice} - {maxPrice}");
                query = query.Where(p => p.Price >= minPrice && p.Price <= maxPrice);

                Console.WriteLine("📌 Query after price filter: " + query.ToQueryString());
            }

            // Sorting
            if (!string.IsNullOrWhiteSpace(foodItemRequestParameters.OrderBy))
            {
                var orderBy = foodItemRequestParameters.OrderBy.Trim().ToLower();
                Console.WriteLine($"📌 Sorting by: {orderBy}");

                query = orderBy switch
                {
                    "price-asc" => query.OrderBy(p => p.Price),
                    "price-desc" => query.OrderByDescending(p => p.Price),

                    _ => query
                };

                Console.WriteLine("📌 Query after sorting: " + query.ToQueryString());
            }

   

            var totalCount = await query.CountAsync();
            Console.WriteLine($"📌 Total products found: {totalCount}");

            var products = await query
                .Skip((foodItemRequestParameters.PageNumber - 1) * foodItemRequestParameters.PageSize)
                .Take(foodItemRequestParameters.PageSize)
                .ToListAsync();

            Console.WriteLine($"📌 Returning {products.Count} products (Page {foodItemRequestParameters.PageNumber})");

            return new PagedList<FoodItem>(products, totalCount,
                foodItemRequestParameters.PageNumber,
                foodItemRequestParameters.PageSize);
        }
        public async Task<IEnumerable<FoodItem>> GetFoodItemByCategoryIdAsync(int categoryId)
        {
            return await _dbSet
                .Where(p => p.CategoryID == categoryId)
                .Include(p => p.Category)
                .AsNoTracking()
                .ToListAsync(); // List<FoodItem> vẫn có thể gán vào IEnumerable<FoodItem>
        }

        public async Task<bool> ProductExistsAsync(int id)
        {
            return await _dbSet.AnyAsync(p => p.FoodItemId == id);
        }

        public async Task<bool> ProductNameExistsAsync(string name)
        {
            return await _dbSet.AnyAsync(p => p.Name == name);
        }
    }
}

using AsmC5.Common.Request;
using AsmC5.Context;
using AsmC5.Interfaces;
using AsmC5.Models;
using Microsoft.EntityFrameworkCore;

namespace AsmC5.Persistence.Repositories
{
    public class ComboRepository : RepositoryBase<Combo>, IComboRepository
    {
        public ComboRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Combo?> GetComboByIdWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(p => p.ComboFoodItems)
                .ThenInclude(p => p.FoodItem) 
                .Include(p => p.ComboFoodItems)
                .ThenInclude(p => p.ComboFoodItemDetails)
                .FirstOrDefaultAsync(p => p.ComboID == id);
        }
        public async Task<PagedList<Combo>> GetComboWithDetailsAsync(
            ComboRequestParameters comboRequestParameters)
        {
            var query = _dbSet
                .Include(p => p.ComboFoodItems)
                .ThenInclude(p => p.ComboFoodItemDetails)
                .AsNoTracking()
                .AsQueryable();

            Console.WriteLine("🔍 Initial Query: " + query.ToQueryString());

            // Search
            if (!string.IsNullOrWhiteSpace(comboRequestParameters.SearchTerm))
            {
                string searchTerm = comboRequestParameters.SearchTerm.Trim().ToLower();
                query = query.Where(p =>
                    (p.Name != null && p.Name.ToLower().Contains(searchTerm)) ||
                    (p.Description != null && p.Description.ToLower().Contains(searchTerm))
                );

                Console.WriteLine($"🔍 Search Term: {searchTerm}");
                Console.WriteLine("📌 Query after search filter: " + query.ToQueryString());
            }

            // Price range filter
            if (comboRequestParameters.PriceRange != null)
            {
                var priceList = comboRequestParameters.PriceRange.Split('-');
                if (priceList.Length == 2 &&
                    int.TryParse(priceList[0], out int minPrice) &&
                    int.TryParse(priceList[1], out int maxPrice))
                {
                    Console.WriteLine($"📌 Filtering by price range: {minPrice} - {maxPrice}");
                    query = query.Where(p => p.Price >= minPrice && p.Price <= maxPrice);
                    Console.WriteLine("📌 Query after price filter: " + query.ToQueryString());
                }
                else
                {
                    Console.WriteLine("⚠️ Invalid price range format.");
                }
            }

            // Sorting
            if (!string.IsNullOrWhiteSpace(comboRequestParameters.OrderBy))
            {
                var orderBy = comboRequestParameters.OrderBy.Trim().ToLower();
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
                .Skip((comboRequestParameters.PageNumber - 1) * comboRequestParameters.PageSize)
                .Take(comboRequestParameters.PageSize)
                .ToListAsync();

            Console.WriteLine($"📌 Returning {products.Count} products (Page {comboRequestParameters.PageNumber})");

            return new PagedList<Combo>(products, totalCount,
                comboRequestParameters.PageNumber,
                comboRequestParameters.PageSize);
        }
        public async Task<bool>ComboExistsAsync(int id)
        {
            return await _dbSet.AnyAsync(p => p.ComboID == id);
        }

        public async Task<bool> ComboNameExistsAsync(string name)
        {
            return await _dbSet.AnyAsync(p => p.Name == name);
        }
    }
}

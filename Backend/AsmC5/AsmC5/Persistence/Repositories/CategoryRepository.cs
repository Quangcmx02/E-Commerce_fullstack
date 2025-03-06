using AsmC5.Common.Request;
using AsmC5.Context;
using AsmC5.Interfaces;
using AsmC5.Models;
using ManboShopAPI.Domain.Exceptions.BadRequest;
using Microsoft.EntityFrameworkCore;

namespace AsmC5.Persistence.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<PagedList<Category>> FetchAllCategoriesWithPaging(CategoryRequestParameters categoryRequestParameters)
        {
            var query = _context.Categories
               
                .AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(categoryRequestParameters.SearchTerm))
            {
                query = query.Where(c => c.Name.Contains(categoryRequestParameters.SearchTerm));
            }

            if (!string.IsNullOrWhiteSpace(categoryRequestParameters.OrderBy))
            {
                var orderBy = categoryRequestParameters.OrderBy.Trim().ToUpper();

                if (orderBy != "ASC" && orderBy != "DESC")
                {
                    throw new CategoryBadRequestException("Điều kiện sắp xếp không hợp lệ. Vui lòng sử dụng ASC hoặc DESC");
                }
                query = orderBy == "ASC" ?
                    query.OrderBy(c => c.Name) :
                    query.OrderByDescending(c => c.Name);
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((categoryRequestParameters.PageNumber - 1) * categoryRequestParameters.PageSize)
                .Take(categoryRequestParameters.PageSize)
                .ToListAsync();

            return new PagedList<Category>(items, totalCount, categoryRequestParameters.PageNumber, categoryRequestParameters.PageSize);
        }

       


        public async Task<bool> CategoryExistsAsync(string categoryName)
        {
            return await _context.Categories.AnyAsync(c => c.Name.Trim().ToLower() == categoryName.Trim().ToLower());
        }

        public async Task<bool> CategoryExistsByIdAsync(int categoryId)
        {
            return await _context.Categories.AnyAsync(c => c.CategoryID == categoryId);
        }
    }
}

using AsmC5.Common.Request;
using AsmC5.Contracts;
using AsmC5.DTOs.CategoryDtos;
using AsmC5.Exceptions.NotFound;
using AsmC5.Interfaces;
using AsmC5.Models;
using AutoMapper;
using ManboShopAPI.Domain.Exceptions.BadRequest;
using Microsoft.EntityFrameworkCore;

namespace AsmC5.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerService _logger;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(ICategoryRepository categoryRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
          
            ILoggerService loggerService
        )
        {
            
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _logger = loggerService;
        }
        public async Task<(IEnumerable<CategoryDto> categories, MetaData metaData)> GetAllCategoriesAsync(CategoryRequestParameters categoryRequestParameters)
        {
            var categories = await _categoryRepository.FetchAllCategoriesWithPaging(categoryRequestParameters);
            _logger.LogInfo("Lấy danh sách danh mục thành công.");
            var categoryDtoList = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return (categoryDtoList, metaData: categories.MetaData);
        }
        public async Task<CategoryDto> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _categoryRepository
                .FindByCondition(c => c.CategoryID == categoryId)
               
                .FirstOrDefaultAsync();
            if (category == null)
            {
                _logger.LogError($"Không tìm thấy danh mục với id {categoryId}");
                throw new CategoryNotFoundException(categoryId);
            }
            _logger.LogInfo($"Lấy dữ liệu danh mục thành công.");
            return _mapper.Map<CategoryDto>(category);
        }
        	public async Task CreateCategoryAsync(CategoryForCreateDto categoryForCreateDto)
		{
			try
			{
				await _unitOfWork.BeginTransactionAsync();

				

				var existingCategory = await _categoryRepository
					.FindByCondition(c => c.Name == categoryForCreateDto.Name)
					.FirstOrDefaultAsync();

				if(existingCategory != null)
				{
					_logger.LogInfo($"Danh mục có tên ${categoryForCreateDto.Name} đã tồn tại");
					throw new CategoryBadRequestException($"Danh mục có tên ${categoryForCreateDto.Name} đã tồn tại");
				}

				var category = _mapper.Map<Category>(categoryForCreateDto);
				await _categoryRepository.AddAsync(category);
				
				await _categoryRepository.SaveChangesAsync();
				await _unitOfWork.CommitAsync();

				_logger.LogInfo("Tạo danh mục mới thành công.");
			} catch (Exception)
			{
				_logger.LogError("Có lỗi xảy ra khi tạo mới danh mục");
				await _unitOfWork.RollbackAsync();
				throw;
			}

		}
        public async Task UpdateCategoryAsync(int categoryId, CategoryForUpdateDto categoryForUpdateDto)
        {

            var existingCategory = await _categoryRepository.GetByIdAsync(categoryId);
            if (existingCategory == null)
            {
                _logger.LogError($"Không tìm thấy danh mục với Id {categoryId}");
                throw new CategoryNotFoundException(categoryId);
            }

            if (existingCategory.Name == categoryForUpdateDto.Name ||
                await CategoryExistsAsync(categoryForUpdateDto.Name))
            {
                _logger.LogError($"Tên danh mục {categoryForUpdateDto.Name} đã tồn tại trong hệ thống.");
                throw new CategoryBadRequestException($"Tên danh mục {categoryForUpdateDto.Name} đã tồn tại trong hệ thống.");
            }


            _mapper.Map(categoryForUpdateDto, existingCategory);
           
            _categoryRepository.Update(existingCategory);
            await _categoryRepository.SaveChangesAsync();
            _logger.LogInfo($"Cập nhật thành công danh mục với Id {existingCategory.CategoryID}");
        }
        public async Task<bool> CategoryExistsAsync(string categoryName)
        {
            return await _categoryRepository.CategoryExistsAsync(categoryName);
        }
        public async Task<CategoryDto> GetCategoryByNameAsync(string categoryName)
        {
            var category = await _categoryRepository
                .FindByCondition(c => c.Name == categoryName)
                .FirstOrDefaultAsync();

            if (category == null)
            {
                _logger.LogError($"Không tìm thấy danh mục với tên là {categoryName}.");
                throw new CategoryNotFoundException($"Không tìm thấy danh mục với tên là {categoryName}.");
            }
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return categoryDto;
        }
        public async Task DeleteCategoryAsync(int categoryId)
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(categoryId);
            if (existingCategory == null)
            {
                _logger.LogError($"Không tìm thấy danh mục với Id {categoryId}");
                throw new CategoryNotFoundException(categoryId);
            }

            _categoryRepository.Remove(existingCategory);
            await _categoryRepository.SaveChangesAsync();
            _logger.LogInfo($"Xóa thành công danh mục với Id {existingCategory.CategoryID}");
        }
    }
}

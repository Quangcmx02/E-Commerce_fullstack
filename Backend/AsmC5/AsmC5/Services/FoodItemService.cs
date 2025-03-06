using System.Diagnostics.Contracts;
using AsmC5.Common.Request;
using AsmC5.Contracts;
using AsmC5.DTOs.CategoryDtos;
using AsmC5.DTOs.FoodItemDtos;
using AsmC5.Exceptions.NotFound;
using AsmC5.Interfaces;
using AsmC5.Models;
using AutoMapper;
using ManboShopAPI.Domain.Exceptions.BadRequest;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Cms;
using MetaData = AsmC5.Common.Request.MetaData;

namespace AsmC5.Services
{
    public class FoodItemService : IFoodItemService
    {
        private readonly IFoodItemRepository _foodItemRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerService _logger;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FoodItemService(
            IFoodItemRepository foodItemRepository,
            ILoggerService logger,
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _foodItemRepository = foodItemRepository;
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        public async Task<(IEnumerable<FoodItemDto> foodItems, MetaData metaData)> GetAllFoodItemAsync(
            FoodItemRequestParameters foodItemRequestParameters)
        {
            var foodItems = await _foodItemRepository.GetFoodItemWithDetailsAsync(foodItemRequestParameters);

            var fooItemDtoList = _mapper.Map<IEnumerable<FoodItemDto>>(foodItems);

            return (fooItemDtoList, foodItems.MetaData);
        }

        public async Task<FoodItemDto> GetFoodItemByIdAsync(int id)
        {
            var foodItem = await _foodItemRepository.GetFoodItemByIdWithDetailsAsync(id);
            if (foodItem == null)
            {
                _logger.LogError($"Không tìm thấy sản phẩm với slug name {id}");
                throw new ProductNotFoundException(id);
            }

            var foodItemDto = _mapper.Map<FoodItemDto>(foodItem);
            return foodItemDto;
        }

        public async Task<IEnumerable<FoodItemDto>> GetFoodItemByCategoryIdAsync(int categoryId)
        {
            var foodItems = await _foodItemRepository.GetFoodItemByCategoryIdAsync(categoryId);

            if (!foodItems.Any())
            {
                throw new ProductNotFoundException("Không tìm thấy sản phẩm trong danh mục này.");
            }

            return _mapper.Map<IEnumerable<FoodItemDto>>(foodItems);
        }

        private async Task ValidateProductData(int? categoryId)
        {
            if (categoryId.HasValue && !await _categoryRepository.CategoryExistsByIdAsync(categoryId.Value))
            {
                _logger.LogError($"Không tìm thấy danh mục với id {categoryId}");
                throw new CategoryNotFoundException(categoryId.Value);
            }


        }

        public async Task<FoodItemDto> CreateProductAsync(FoodItemForCreateDto productDto)
        {
            // 1️⃣ Kiểm tra dữ liệu đầu vào
            if (productDto == null)
            {
                _logger.LogError("Dữ liệu sản phẩm không được null.");
                throw new ProductBadRequestException("Dữ liệu sản phẩm không hợp lệ.");
            }

            if (string.IsNullOrWhiteSpace(productDto.Name))
            {
                _logger.LogError("Tên sản phẩm không được để trống.");
                throw new ProductBadRequestException("Tên sản phẩm không được để trống.");
            }

            if (productDto.Price <= 0)
            {
                _logger.LogError("Giá sản phẩm phải lớn hơn 0.");
                throw new ProductBadRequestException("Giá sản phẩm phải lớn hơn 0.");
            }

            if (productDto.Quantity < 0)
            {
                _logger.LogError("Số lượng sản phẩm không được âm.");
                throw new ProductBadRequestException("Số lượng sản phẩm không được âm.");
            }

            if (productDto.CategoryID <= 0)
            {
                _logger.LogError("Danh mục không hợp lệ.");
                throw new ProductBadRequestException("Danh mục sản phẩm không hợp lệ.");
            }

            if (string.IsNullOrWhiteSpace(productDto.ImagePath))
            {
                _logger.LogError("Đường dẫn hình ảnh không được để trống.");
                throw new ProductBadRequestException("Vui lòng nhập đường dẫn hình ảnh.");
            }

            try
            {
                // 2️⃣ Bắt đầu giao dịch
                await _unitOfWork.BeginTransactionAsync();

                // 3️⃣ Kiểm tra tên sản phẩm có bị trùng không
                if (await _foodItemRepository.ProductNameExistsAsync(productDto.Name))
                {
                    _logger.LogError($"Sản phẩm với tên '{productDto.Name}' đã tồn tại.");
                    throw new ProductBadRequestException($"Sản phẩm với tên '{productDto.Name}' đã tồn tại.");
                }

                // 4️⃣ Ánh xạ DTO -> Entity
                var product = _mapper.Map<FoodItem>(productDto);
                await _foodItemRepository.AddAsync(product);
                await _foodItemRepository.SaveChangesAsync();

                // 5️⃣ Ánh xạ Entity -> DTO để trả về
                var productDTO = new FoodItemDto
                {
                    FoodItemId = product.FoodItemId,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    IsAvailable = product.IsAvailable,
                    Quantity = product.Quantity,

                    ImagePath = product.ImagePath,
                    Category = _mapper.Map<CategoryDto>(product.Category)
                };

                // 6️⃣ Commit giao dịch và log thành công
                await _unitOfWork.CommitAsync();
                _logger.LogInfo($"Tạo sản phẩm mới '{product.Name}' thành công.");

                return productDTO;
            }
            catch (Exception ex)
            {
                // 7️⃣ Rollback nếu có lỗi
                await _unitOfWork.RollbackAsync();
                _logger.LogError($"Tạo sản phẩm mới thất bại. Lỗi: {ex.Message}");
                throw;
            }

        }

        public async Task<FoodItemDto> UpdateProductAsync(int productId, FoodItemForUpdateDto productDto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                // 🔹 Kiểm tra sản phẩm có tồn tại không
                var existingProduct = await _foodItemRepository
                    .FindByCondition(p => p.FoodItemId == productId)
                    .Include(p => p.Category)
                    .FirstOrDefaultAsync();

                if (existingProduct == null)
                {
                    _logger.LogError($"Không tìm thấy sản phẩm với ID {productId}");
                    throw new ProductNotFoundException($"Không tìm thấy sản phẩm với ID {productId}.");
                }

                // 🔹 Kiểm tra xem có sản phẩm nào khác trùng tên không
                if (await _foodItemRepository.ProductNameExistsAsync(productDto.Name))
                {
                    _logger.LogError($"Sản phẩm với tên '{productDto.Name}' đã tồn tại.");
                    throw new ProductBadRequestException($"Sản phẩm với tên '{productDto.Name}' đã tồn tại.");
                }

                // 🔹 Validate các thông tin khác
                if (productDto.Price < 0)
                {
                    throw new ProductBadRequestException("Giá sản phẩm phải lớn hơn hoặc bằng 0.");
                }

                if (productDto.Quantity < 0)
                {
                    throw new ProductBadRequestException("Số lượng sản phẩm không được âm.");
                }

                if (string.IsNullOrWhiteSpace(productDto.ImagePath))
                {
                    throw new ProductBadRequestException("Vui lòng nhập đường dẫn hình ảnh.");
                }

                // 🔹 Cập nhật thông tin sản phẩm
                _mapper.Map(productDto, existingProduct);
                _foodItemRepository.Update(existingProduct);
                await _foodItemRepository.SaveChangesAsync();

                // 🔹 Ánh xạ sang DTO để trả về
                var updatedProductDTO = _mapper.Map<FoodItemDto>(existingProduct);

                await _unitOfWork.CommitAsync();
                _logger.LogInfo($"Cập nhật sản phẩm '{existingProduct.Name}' thành công.");

                return updatedProductDTO;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                _logger.LogError($"Cập nhật sản phẩm thất bại. Lỗi: {ex.Message}");
                throw;
            }
        }
        public async Task DeleteProductAsync(int productId)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var existingProduct = await _foodItemRepository
                    .FindByCondition(p => p.FoodItemId == productId)
                   
                    .FirstOrDefaultAsync();

                if (existingProduct == null)
                {
                    throw new ProductNotFoundException(productId);
                }

               
                _foodItemRepository.Remove(existingProduct);

                // 10. Lưu các thay đổi
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();

                _logger.LogInfo($"Xóa sản phẩm với id {productId} thành công.");
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                _logger.LogError($"Xóa sản phẩm với id {productId} thất bại.");
                throw;
            }
        }

    }
}


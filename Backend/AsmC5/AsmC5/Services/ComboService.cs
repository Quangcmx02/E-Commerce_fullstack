using AsmC5.Common.Request;
using AsmC5.Contracts;
using AsmC5.DTOs.ComboDtos;
using AsmC5.DTOs.FoodItemDtos;
using AsmC5.Exceptions.NotFound;
using AsmC5.Interfaces;
using AsmC5.Models;
using AsmC5.Persistence.Repositories;
using AutoMapper;
using ManboShopAPI.Domain.Exceptions.BadRequest;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;


namespace AsmC5.Services
{
    public class ComboService : IComboService
    {
        private readonly IComboRepository _comboRepository;
        private readonly IFoodItemRepository _foodItemRepository;
        private readonly IMapper _mapper;
        private readonly IComboFoodItemRepository _comboFoodItemRepository;
        private readonly IComboFoodItemDetailRepository _comboFoodItemDetailRepository;
        private readonly ILoggerService _logger;
        private readonly IUnitOfWork _unitOfWork;
        public ComboService(
            IComboRepository comboRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IComboFoodItemRepository comboFoodItemRepository,
            IComboFoodItemDetailRepository comboFoodItemDetailRepository,
            IFoodItemRepository foodItemRepository,
            ILoggerService logger)
        {
            _foodItemRepository = foodItemRepository;
            _comboRepository = comboRepository;
            _mapper = mapper;
            _comboFoodItemRepository = comboFoodItemRepository;
            _comboFoodItemDetailRepository = comboFoodItemDetailRepository;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public async Task<(IEnumerable<ComboDto> comboDtos, MetaData metaData)> GetAllComboAsync(ComboRequestParameters comboRequestParameters)
        {
            var foodItems = await _comboRepository.GetComboWithDetailsAsync(comboRequestParameters);

            var fooItemDtoList = _mapper.Map<IEnumerable<ComboDto>>(foodItems);

            return (fooItemDtoList, foodItems.MetaData);
        }
        public async Task<ComboDto> GetComboByIdAsync(int id)
        {
            var foodItem = await _comboRepository.GetComboByIdWithDetailsAsync(id);
            if (foodItem == null)
            {
                throw new Exception("Không tìm thấy sản phẩm.");
            }
            var foodItemDto = _mapper.Map<ComboDto>(foodItem);
            return foodItemDto;
        }

        public async Task<ComboDto> CreateComboAsync(ComboForCreateDto comboDto)
        {
            try
            {
                // 1️⃣ Kiểm tra dữ liệu đầu vào
                if (comboDto == null)
                {
                    _logger.LogError("Dữ liệu tạo combo không được null.");
                    throw new ProductBadRequestException("Dữ liệu tạo combo không hợp lệ.");
                }

                if (string.IsNullOrWhiteSpace(comboDto.Name))
                {
                    throw new ProductBadRequestException("Tên combo không được để trống.");
                }

                if (comboDto.Price < 0)
                {
                    throw new ProductBadRequestException("Giá combo phải >= 0.");
                }

                if (comboDto.ComboFoodItemForCreateDto == null || !comboDto.ComboFoodItemForCreateDto.Any())
                {
                    throw new ProductBadRequestException("Combo phải chứa ít nhất một sản phẩm.");
                }

                await _unitOfWork.BeginTransactionAsync();

                // 2️⃣ Tạo entity combo từ DTO
                var newCombo = _mapper.Map<Combo>(comboDto);
                _comboRepository.AddAsync(newCombo);
                await _unitOfWork.SaveChangesAsync();

                // 3️⃣ Thêm từng `ComboFoodItem`
                foreach (var comboItemDto in comboDto.ComboFoodItemForCreateDto)
                {
                    var foodItem = await _foodItemRepository.GetByIdAsync(comboItemDto.FoodItemID);
                    if (foodItem == null)
                    {
                        throw new ProductNotFoundException($"Không tìm thấy sản phẩm với ID {comboItemDto.FoodItemID}.");
                    }

                    var newComboFoodItem = new ComboFoodItem
                    {
                        ComboID = newCombo.ComboID,
                        FoodItemID = comboItemDto.FoodItemID
                    };

                    _comboFoodItemRepository.AddAsync(newComboFoodItem);
                    await _unitOfWork.SaveChangesAsync();

                    // 4️⃣ Thêm từng `ComboFoodItemDetail`
                    if (comboItemDto.COmboFoodItemDetailsFOrCreateDtos != null)
                    {
                        foreach (var detailDto in comboItemDto.COmboFoodItemDetailsFOrCreateDtos)
                        {
                            var newComboFoodItemDetail = new ComboFoodItemDetail
                            {
                                ComboFoodItemId = newComboFoodItem.ComboFoodItemID,
                                QuantityFoodInCombo = detailDto.QuantityFoodInCombo
                            };

                            _comboFoodItemDetailRepository.AddAsync(newComboFoodItemDetail);
                        }
                    }
                }

                await _unitOfWork.CommitAsync();

                // 5️⃣ Ánh xạ kết quả và trả về
                var createdComboDto = _mapper.Map<ComboDto>(newCombo);
                _logger.LogInfo($"Tạo combo '{newCombo.Name}' thành công.");

                return createdComboDto;
            }
            catch (Exception ex)
            {
                //await _unitOfWork.RollbackAsync();
                _logger.LogError($"Tạo combo thất bại. Lỗi: {ex.Message}");
                throw;
            }
        }
        public async Task<ComboDto> UpdateComboAsync(int comboId, ComboForUpdateDto productDto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                // 🔹 Kiểm tra sản phẩm có tồn tại không
                var existingProduct = await _comboRepository
                    .FindByCondition(p => p.ComboID == comboId)
                    
                    .FirstOrDefaultAsync();

                if (existingProduct == null)
                {
                    _logger.LogError($"Không tìm thấy sản phẩm với ID {comboId}");
                    throw new ProductNotFoundException($"Không tìm thấy sản phẩm với ID {comboId}.");
                }

                // 🔹 Kiểm tra xem có sản phẩm nào khác trùng tên không
                if (await _comboRepository.ComboNameExistsAsync(productDto.Name))
                {
                    _logger.LogError($"Sản phẩm với tên '{productDto.Name}' đã tồn tại.");
                    throw new ProductBadRequestException($"Sản phẩm với tên '{productDto.Name}' đã tồn tại.");
                }

                // 🔹 Validate các thông tin khác
                if (productDto.Price < 0)
                {
                    throw new ProductBadRequestException("Giá sản phẩm phải lớn hơn hoặc bằng 0.");
                }

                if (productDto.QuantityCombo < 0)
                {
                    throw new ProductBadRequestException("Số lượng sản phẩm không được âm.");
                }

                if (string.IsNullOrWhiteSpace(productDto.ImagePath))
                {
                    throw new ProductBadRequestException("Vui lòng nhập đường dẫn hình ảnh.");
                }

                // 🔹 Cập nhật thông tin sản phẩm
                _mapper.Map(productDto, existingProduct);
                _comboRepository.Update(existingProduct);
                await _foodItemRepository.SaveChangesAsync();

                // 🔹 Ánh xạ sang DTO để trả về
                var updatedProductDTO = _mapper.Map<ComboDto>(existingProduct);

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

                var existingProduct = await _comboRepository
                    .FindByCondition(p => p.ComboID == productId)
                    .Include(p => p.ComboFoodItems)
                    .ThenInclude(p => p.ComboFoodItemDetails)
                   
                    .FirstOrDefaultAsync();

                if (existingProduct == null)
                {
                    throw new ProductNotFoundException(productId);
                }

                foreach (var item in existingProduct.ComboFoodItems)
                {
                    _comboFoodItemDetailRepository.RemoveRange(item.ComboFoodItemDetails);
                }

               
                _comboFoodItemRepository.RemoveRange(existingProduct.ComboFoodItems);
             
              

              
                _comboRepository.Remove(existingProduct);

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

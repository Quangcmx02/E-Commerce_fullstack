using AsmC5.Contracts;
using AsmC5.DTOs.CartDtos;
using AsmC5.DTOs.CartItemDtos;
using AsmC5.DTOs.OrderDtos;
using AsmC5.Exceptions.NotFound;
using AsmC5.Interfaces;
using AsmC5.Models;
using AutoMapper;
using ManboShopAPI.Domain.Exceptions.BadRequest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;

namespace AsmC5.Services
{
    public class CartService: ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILoggerService _logger;
        private readonly ICartRepository _cartRepository;
        private readonly IFoodItemRepository _foodItemRepository;
        private readonly IComboRepository _comboRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository; //
        public CartService(
        
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IUserRepository userRepository,
            ILoggerService logger,
            ICartRepository cartRepository,
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IComboRepository comboRepository,
            IFoodItemRepository foodItemRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _orderDetailRepository = orderDetailRepository;
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _cartRepository = cartRepository;
            _comboRepository = comboRepository;
            _foodItemRepository = foodItemRepository;
            _comboRepository = comboRepository;
        }
        public async Task<CartDto> GetCartBySessionIdAsync(string sessionId)
        {
            var cart = await _cartRepository.GetCartBySessionIdAsync(sessionId);
            if (cart == null)
                throw new CartNotFoundException($"Không tìm thấy giỏ hàng với SessionId {sessionId}");

            return _mapper.Map<CartDto>(cart);
        }
        public async Task<CartDto> GetCartByUserIdAsync(string userId)
        {
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            if (cart == null)
                throw new CartNotFoundException($"Không tìm thấy giỏ hàng của người dùng {userId}", false);

            return _mapper.Map<CartDto>(cart);
        }

        public async Task<CartDto> CreateCartAsync(CartForCreateDto cartDto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                if (cartDto.UserId == null && cartDto.SessionId == null)
                    throw new CartBadRequestException("UserId hoặc SessionId không được để trống");

                if (cartDto.UserId != null && cartDto.SessionId != null)
                    throw new CartBadRequestException("Chỉ được chọn một trong hai UserId hoặc SessionId");

                // Kiểm tra cart tồn tại
                if (cartDto.SessionId != null)
                {
                    var existingSessionCart = await _cartRepository.GetCartBySessionIdAsync(cartDto.SessionId);
                    if (existingSessionCart != null)
                        throw new CartBadRequestException($"Giỏ hàng với SessionId {cartDto.SessionId} đã tồn tại");
                }

                if (cartDto.UserId != null)
                {
                    var existingUserCart = await _cartRepository.GetCartByUserIdAsync(cartDto.UserId);
                    if (existingUserCart != null)
                        throw new CartBadRequestException($"Người dùng {cartDto.UserId} đã có giỏ hàng");
                }

                var cart = _mapper.Map<Cart>(cartDto);
                await _cartRepository.AddAsync(cart);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();

                return _mapper.Map<CartDto>(cart);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<CartDto> GetOrCreateCartByUserAsync(string userId)
        {
            _logger.LogInfo($"🔍 Tìm giỏ hàng cho UserID: {userId}");

            var cart = await _cartRepository.GetCartByUserIdAsync(userId);

            if (cart == null)
            {
                _logger.LogWarning($"⚠️ Không tìm thấy giỏ hàng cho UserID: {userId}, tạo mới...");

                var newCart = new Cart
                {
                    UserID = userId
                };
                await _cartRepository.AddAsync(newCart);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInfo($"✅ Đã tạo giỏ hàng mới với ID: {newCart.CartID} cho UserID: {userId}");

                cart = newCart;
            }
            else
            {
                _logger.LogInfo($"✅ Đã tìm thấy giỏ hàng với ID: {cart.CartID} cho UserID: {userId}");
            }

            return _mapper.Map<CartDto>(cart);
        }

        public async Task<CartDto> GetOrCreateCartBySessionAsync(string sessionId)
        {
            var cart = await _cartRepository.GetCartBySessionIdAsync(sessionId);

            if (cart == null)
            {
                var newCart = new Cart
                {
                    SessionId = sessionId
                };
                await _cartRepository.AddAsync(newCart);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInfo($"Tạo giỏ hàng mới với SessionId {sessionId}");
                cart = newCart;
            }

            return _mapper.Map<CartDto>(cart);
        }
        public async Task<bool> DoesCartExistAsync(string sessionId)
        {
            return await _cartRepository.IsCartExistsAsync(sessionId);
        }
        public async Task DeleteCartAsync(int cartId)
        {
            var cart = await _cartRepository.GetByIdAsync(cartId);
            if (cart == null)
                throw new CartNotFoundException($"Không tìm thấy giỏ hàng {cartId}");

            _cartRepository.Remove(cart);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<CartItemDto> AddItemToCartforguestAsync(int cartId, CartItemForCreateDto cartItemDto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                // 🔸 Tìm giỏ hàng, nếu không có thì tạo mới
                var cart = await _cartRepository
                    .FindByCondition(c => c.CartID == cartId, true)
                    .Include(c => c.CartItems)
                    .AsTracking()
                    .FirstOrDefaultAsync();

                if (cart == null)
                {
                    cart = new Cart { CartID = cartId };
                    await _cartRepository.AddAsync(cart);
                    await _unitOfWork.SaveChangesAsync();
                }

                CartItem existingItem = null;

                // 🔸 Nếu là sản phẩm đơn lẻ (FoodItem)
                if (cartItemDto.FoodItemID.HasValue)
                {
                    var foodItem = await _foodItemRepository.GetByIdAsync(cartItemDto.FoodItemID.Value);
                    if (foodItem == null)
                        throw new ProductNotFoundException($"Không tìm thấy sản phẩm {cartItemDto.FoodItemID}");

                    existingItem = cart.CartItems.FirstOrDefault(ci => ci.FoodItemID == cartItemDto.FoodItemID);
                }

                // 🔸 Nếu là Combo
                if (cartItemDto.ComboID.HasValue)
                {
                    var combo = await _comboRepository.GetByIdAsync(cartItemDto.ComboID.Value);
                    if (combo == null)
                        throw new ProductNotFoundException($"Không tìm thấy combo {cartItemDto.ComboID}");

                    existingItem = cart.CartItems.FirstOrDefault(ci => ci.ComboID == cartItemDto.ComboID);
                }

                // 🔸 Nếu sản phẩm/combo đã tồn tại trong giỏ hàng → cập nhật số lượng
                if (existingItem != null)
                {
                    if (cartItemDto.FoodItemID.HasValue)
                        existingItem.QuantityFoodItem += cartItemDto.QuantityFoodItem;
                    if (cartItemDto.ComboID.HasValue)
                        existingItem.QuantityCombo += cartItemDto.QuantityCombo;

                    _cartRepository.Update(cart);
                }
                else
                {
                    // 🔸 Nếu chưa tồn tại → tạo mới
                    var cartItem = new CartItem
                    {
                        CartID = cart.CartID,
                        FoodItemID = cartItemDto.FoodItemID,
                        ComboID = cartItemDto.ComboID,
                        QuantityFoodItem = cartItemDto.QuantityFoodItem,
                        QuantityCombo = cartItemDto.QuantityCombo
                    };

                    cart.CartItems.Add(cartItem);
                }

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();

                // 🔸 Lấy item vừa thêm để map DTO trả về
                var updatedItem = cart.CartItems.FirstOrDefault(ci =>
                    ci.FoodItemID == cartItemDto.FoodItemID || ci.ComboID == cartItemDto.ComboID);

                return _mapper.Map<CartItemDto>(updatedItem);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
        public async Task<CartItemDto> AddItemToCartAsync(int cartId, CartItemForCreateDto cartItemDto, string userId)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                // 🔸 Tìm giỏ hàng theo UserID (vì UserID là unique)
                var cart = await _cartRepository
                    .FindByCondition(c => c.UserID == userId, true)
                    .Include(c => c.CartItems)
                    .AsTracking()
                    .FirstOrDefaultAsync();

                // 🔸 Nếu không có, tạo giỏ hàng mới
                if (cart == null)
                {
                    cart = new Cart
                    {
                        CartID = cartId,
                        UserID = userId  
                    };
                    await _cartRepository.AddAsync(cart);
                    await _unitOfWork.SaveChangesAsync();
                }

                CartItem existingItem = null;

  
                if (cartItemDto.FoodItemID.HasValue)
                {
                    var foodItem = await _foodItemRepository.GetByIdAsync(cartItemDto.FoodItemID.Value);
                    if (foodItem == null) throw new ProductNotFoundException($"Không tìm thấy sản phẩm {cartItemDto.FoodItemID}");

                    existingItem = cart.CartItems.FirstOrDefault(ci => ci.FoodItemID == cartItemDto.FoodItemID);
                }


                if (cartItemDto.ComboID.HasValue)
                {
                    var combo = await _comboRepository.GetByIdAsync(cartItemDto.ComboID.Value);
                    if (combo == null)
                        throw new ProductNotFoundException($"Không tìm thấy combo {cartItemDto.ComboID}");

                    existingItem = cart.CartItems.FirstOrDefault(ci => ci.ComboID == cartItemDto.ComboID);
                }


                if (existingItem != null)
                {
                    if (cartItemDto.FoodItemID.HasValue)
                        existingItem.QuantityFoodItem += cartItemDto.QuantityFoodItem;
                    if (cartItemDto.ComboID.HasValue)
                        existingItem.QuantityCombo += cartItemDto.QuantityCombo;

                    _cartRepository.Update(cart);
                }
                else
                {

                    var cartItem = new CartItem
                    {
                        CartID = cart.CartID,
                        FoodItemID = cartItemDto.FoodItemID,
                        ComboID = cartItemDto.ComboID,
                        QuantityFoodItem = cartItemDto.QuantityFoodItem,
                        QuantityCombo = cartItemDto.QuantityCombo
                    };

                    cart.CartItems.Add(cartItem);
                }

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();

                // 🔸 Lấy item vừa thêm để map DTO trả về
                var updatedItem = cart.CartItems.FirstOrDefault(ci =>
                    ci.FoodItemID == cartItemDto.FoodItemID || ci.ComboID == cartItemDto.ComboID);

                return _mapper.Map<CartItemDto>(updatedItem);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
        public async Task<CartItemDto> UpdateCartItemQuantityAsync(int cartId, int? foodItemId, int? comboId, CartItemForUpdateDto updateDto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                // 🔹 Tìm giỏ hàng theo ID, include CartItems
                var cart = await _cartRepository
                    .FindByCondition(c => c.CartID == cartId, true)
                    .Include(c => c.CartItems)
                    .AsTracking()
                    .FirstOrDefaultAsync();

                if (cart == null)
                    throw new CartNotFoundException("Không tìm thấy giỏ hàng.");

                CartItem existingItem = null;

                // 🔹 Nếu cập nhật sản phẩm đơn
                if (foodItemId.HasValue)
                {
                    existingItem = cart.CartItems.FirstOrDefault(ci => ci.FoodItemID == foodItemId);

                    if (existingItem == null)
                    {
                        var foodItem = await _foodItemRepository.GetByIdAsync(foodItemId.Value);
                        if (foodItem == null)
                            throw new CartNotFoundException($"Không tìm thấy sản phẩm {foodItemId}");

                        // Kiểm tra tồn kho
                        if (updateDto.QuantityFoodItem > foodItem.Quantity)
                            throw new ValidationException($"Số lượng sản phẩm {foodItemId} không đủ trong kho. Hiện còn {foodItem.Quantity}.");

                        // 🔹 Tạo mới CartItem nếu chưa có
                        existingItem = new CartItem
                        {
                            CartID = cartId,
                            FoodItemID = foodItemId.Value,
                            QuantityFoodItem = updateDto.QuantityFoodItem
                        };
                        cart.CartItems.Add(existingItem);
                    }
                    else
                    {
                        // 🔹 Cập nhật số lượng nếu sản phẩm đã có
                        existingItem.QuantityFoodItem = updateDto.QuantityFoodItem;
                    }
                }

                // 🔹 Nếu cập nhật combo
                if (comboId.HasValue)
                {
                    existingItem = cart.CartItems.FirstOrDefault(ci => ci.ComboID == comboId);

                    if (existingItem == null)
                    {
                        var combo = await _comboRepository.GetByIdAsync(comboId.Value);
                        if (combo == null)
                            throw new CartNotFoundException($"Không tìm thấy combo {comboId}");

                        // Kiểm tra tồn kho
                        if (updateDto.QuantityCombo > combo.QuantityCombo)
                            throw new ValidationException($"Số lượng combo {comboId} không đủ trong kho. Hiện còn {combo.QuantityCombo}.");

                        // 🔹 Tạo mới CartItem nếu chưa có
                        existingItem = new CartItem
                        {
                            CartID = cartId,
                            ComboID = comboId.Value,
                            QuantityCombo = updateDto.QuantityCombo
                        };
                        cart.CartItems.Add(existingItem);
                    }
                    else
                    {
                        // 🔹 Cập nhật số lượng nếu combo đã có
                        existingItem.QuantityCombo = updateDto.QuantityCombo;
                    }
                }

                _cartRepository.Update(cart);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();

                return _mapper.Map<CartItemDto>(existingItem);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }


        public async Task RemoveCartItemAsync(int cartId, int? foodItemId, int? comboId)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var cart = await _cartRepository
                    .FindByCondition(c => c.CartID == cartId)
                    .Include(c => c.CartItems)
                    .AsTracking()
                    .FirstOrDefaultAsync();

                if (cart == null)
                    throw new CartNotFoundException($"Không tìm thấy giỏ hàng {cartId}");

                var itemsToRemove = cart.CartItems
                    .Where(ci => (foodItemId.HasValue && ci.FoodItemID == foodItemId) ||
                                 (comboId.HasValue && ci.ComboID == comboId))
                    .ToList();

                if (!itemsToRemove.Any())
                    throw new CartNotFoundException("Không tìm thấy sản phẩm hoặc combo trong giỏ hàng.");

                foreach (var item in itemsToRemove)
                {
                    cart.CartItems.Remove(item);
                }

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
        public async Task<IEnumerable<CartItemDto>> GetCartItemsAsync(int cartId)
        {
            var cart = await _cartRepository
                .FindByCondition(c => c.CartID == cartId)
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.FoodItem)  
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Combo)    
                .AsNoTracking() 
                .FirstOrDefaultAsync();

            if (cart == null)
                throw new CartNotFoundException($"Không tìm thấy giỏ hàng {cartId}");

            return _mapper.Map<IEnumerable<CartItemDto>>(cart.CartItems);
        }
        public async Task<decimal> GetCartTotalAsync(int cartId)
        {
            return await _cartRepository.GetCartTotalAsync(cartId);
        }
        public async Task<OrderDto> CheckoutCartAsync(string userId, OrderForCreateDto orderForCreateDto)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var user = await _userRepository.FindByCondition(u => u.Id == userId)
                                                            
                                                            .FirstOrDefaultAsync();

                if (user == null)
                    throw new UserNotFoundException($"Không tìm thấy người dùng {userId}");

                var cart = await _cartRepository.FindByCondition(c => c.CartID == orderForCreateDto.CartId)
                    .AsTracking()
                    .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.FoodItem)  // Chỉ Include nếu có khóa ngoại hợp lệ
                    .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.Combo)
                    .ThenInclude(co => co.ComboFoodItems)
                    .ThenInclude(cfi => cfi.ComboFoodItemDetails)
                    .FirstOrDefaultAsync();


                if (cart == null)
                    throw new CartNotFoundException($"Không tìm thấy giỏ hàng {orderForCreateDto.CartId}");

                if (!cart.CartItems.Any())
                    throw new CartBadRequestException("Giỏ hàng trống");



                // Kiểm tra số lượng tồn kho
                foreach (var item in cart.CartItems)
                {
                    if (item.FoodItem != null && item.QuantityFoodItem.HasValue && item.FoodItem.Quantity < item.QuantityFoodItem.Value)
                    {
                        throw new CartBadRequestException($"Sản phẩm {item.FoodItem.Name} không đủ số lượng trong kho");
                    }

                    if (item.Combo != null && item.QuantityCombo.HasValue && item.Combo.QuantityCombo < item.QuantityCombo.Value)
                    {
                        throw new CartBadRequestException($"Combo {item.Combo.ComboID} không đủ số lượng trong kho");
                    }
                }


                decimal subTotal = await GetCartTotalAsync(orderForCreateDto.CartId);

                var order = new Order
                {
                    UserID = userId,
                    OrderTime = DateTime.UtcNow,
                    Status = OrderStatus.Pending,
                    TotalAmount = subTotal,
                   
                   
                };

                await _orderRepository.AddAsync(order);
                await _unitOfWork.SaveChangesAsync();
                // Tạo chi tiết đơn hàng
                foreach (var item in cart.CartItems)
                {
                    var orderDetail = new OrderDetail
                    {
                        OrderID = order.OrderID,
                        QuantityFoodItem = item.QuantityFoodItem,
                        QuantityCombo = item.QuantityCombo,
                       
                        FoodItemID = item.FoodItemID,
                        ComboID = item.ComboID,
                        
                        Price = subTotal
                    };
                    await _orderDetailRepository.AddAsync(orderDetail);
                    
                    // Cập nhật số lượng trong kho
                    if (item.FoodItem != null && item.QuantityFoodItem !=null)
                    {
                        item.FoodItem.Quantity -= item.QuantityFoodItem.Value;
                        _foodItemRepository.Update(item.FoodItem);
                    }

                    if (item.Combo != null && item.QuantityCombo != null)
                    {
                        item.Combo.QuantityCombo -= item.QuantityCombo.Value;
                        _comboRepository.Update(item.Combo);
                    }
                }


                await _cartRepository.ClearCartAsync(orderForCreateDto.CartId);
                await _unitOfWork.CommitAsync();

               

                return _mapper.Map<OrderDto>(order);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                _logger.LogError("Lỗi khi tạo đơn hàng");
                throw;
            }
        }
        public async Task ClearCartAsync(int cartId)
        {
            await _cartRepository.ClearCartAsync(cartId);
        }
    }
}


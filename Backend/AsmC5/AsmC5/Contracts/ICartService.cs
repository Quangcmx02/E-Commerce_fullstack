using AsmC5.DTOs.CartDtos;
using AsmC5.DTOs.CartItemDtos;
using AsmC5.DTOs.OrderDtos;

namespace AsmC5.Contracts
{
    public interface ICartService
    {
        
        Task<CartItemDto> AddItemToCartAsync(int cartId, CartItemForCreateDto cartItemDto, string userId);

        Task<CartItemDto> AddItemToCartforguestAsync(int cartId, CartItemForCreateDto cartItemDto);

        Task<CartItemDto> UpdateCartItemQuantityAsync(int cartId, int? foodItemId, int? comboId,
            CartItemForUpdateDto updateDto);

        Task ClearCartAsync(int cartId);
        Task RemoveCartItemAsync(int cartId, int? foodItemId, int? comboId);
        Task<IEnumerable<CartItemDto>> GetCartItemsAsync(int cartId);
        Task<OrderDto> CheckoutCartAsync(string userId, OrderForCreateDto orderForCreateDto);
            Task DeleteCartAsync(int cartId);
        Task<bool> DoesCartExistAsync(string sessionId);
        Task<CartDto> CreateCartAsync(CartForCreateDto cartDto);
        Task<CartDto> GetOrCreateCartByUserAsync(string userId);
        Task<CartDto> GetCartByUserIdAsync(string userId);
        Task<CartDto> GetOrCreateCartBySessionAsync(string sessionId);
        Task<CartDto> GetCartBySessionIdAsync(string sessionId);

    }
}

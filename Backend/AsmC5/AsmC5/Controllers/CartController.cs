using AsmC5.Common.Response;
using AsmC5.Contracts;
using AsmC5.DTOs.CartDtos;
using AsmC5.DTOs.CartItemDtos;
using AsmC5.DTOs.OrderDtos;
using AsmC5.Fillters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Security.Claims;

namespace AsmC5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly ISessionService _sessionService;

        public CartController(ICartService cartService, ISessionService sessionService)
        {
            _cartService = cartService;
            _sessionService = sessionService;
        }
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CartDto>> GetCart()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var cart = await _cartService.GetCartByUserIdAsync(userId);
                return Ok(new ApiResponse<object>
                {
                    StatusCode = 200,
                    Success = true,
                    Message = "Lấy thông tin giỏ hàng thành công.",
                    Data = cart
                });
            }
            else
            {
                // Try to get existing session ID or create a new one if not exists
                var sessionId = HttpContext.Request.Cookies["CartSessionId"];
                if (string.IsNullOrEmpty(sessionId))
                {
                    // If no session ID exists, create a new one
                    sessionId = await _sessionService.CreateNewSessionId(HttpContext);

                    // Create a new cart for this session
                    var newCart = new CartForCreateDto
                    {
                        SessionId = sessionId
                    };
                    await _cartService.CreateCartAsync(newCart);
                }

                // Retrieve cart by session ID
                var cart = await _cartService.GetCartBySessionIdAsync(sessionId);

                return Ok(new ApiResponse<object>
                {
                    StatusCode = 200,
                    Success = true,
                    Message = "Lấy thông tin giỏ hàng thành công.",
                    Data = cart
                });
            }
        }
        [HttpGet("session/{sessionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CartDto>> GetCartBySessionId(string sessionId)
        {
            var cart = await _cartService.GetCartBySessionIdAsync(sessionId);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = $"Lấy thông tin giỏ hàng với SessionId {sessionId} thành công.",
                Data = cart
            });
        }

        [HttpGet("user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CartDto>> GetCartByUserId(string userId)
        {
            var cart = await _cartService.GetCartByUserIdAsync(userId);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = $"Lấy thông tin giỏ hàng của người dùng {userId} thành công.",
                Data = cart
            });
        }
        [HttpPost("items")]
        [ValidationFilter]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CartItemDto>> AddItemToCart([FromBody] CartItemForCreateDto cartItemDto )
        {
            CartItemDto cartItem;


            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                 var userCart = await _cartService.GetOrCreateCartByUserAsync(userId);
                 cartItem = await _cartService.AddItemToCartAsync(userCart.CartID, cartItemDto, userId);
            }
            else
            {
                var sessionId = _sessionService.GetSessionId(HttpContext);
                var sessionCart = await _cartService.GetCartBySessionIdAsync(sessionId);
                cartItem = await _cartService.AddItemToCartforguestAsync(sessionCart.CartID, cartItemDto);
            }

            return StatusCode(201, new ApiResponse<object>
            {
                StatusCode = 201,
                Success = true,
                Message = "Thêm sản phẩm vào giỏ hàng thành công.",
                Data = cartItem
            });
        }
        [HttpPut("items")]
        [ValidationFilter]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CartItemDto>> UpdateCartItem([FromBody] CartItemForUpdateDto cartItemDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            CartItemDto cartItem;

            if (User.Identity.IsAuthenticated)
            {
                 userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var userCart = await _cartService.GetOrCreateCartByUserAsync(userId);
                cartItem = await _cartService.UpdateCartItemQuantityAsync(userCart.CartID, cartItemDto.FoodItemID, cartItemDto.ComboID, cartItemDto);
            }
            else
            {
                var sessionId = _sessionService.GetSessionId(HttpContext);
                var sessionCart = await _cartService.GetCartBySessionIdAsync(sessionId);
                cartItem = await _cartService.UpdateCartItemQuantityAsync(sessionCart.CartID, cartItemDto.FoodItemID, cartItemDto.ComboID, cartItemDto);
            }

            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = "Cập nhật sản phẩm trong giỏ hàng thành công.",
                Data = cartItem
            });
        

        }
        [HttpDelete("items/{itemId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveCartItem(int? foodItemId, int? comboId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var userCart = await _cartService.GetOrCreateCartByUserAsync(userId);
                await _cartService.RemoveCartItemAsync(userCart.CartID, foodItemId, comboId);
            }
            else
            {
                var sessionId = _sessionService.GetSessionId(HttpContext);
                var sessionCart = await _cartService.GetCartBySessionIdAsync(sessionId);
                await _cartService.RemoveCartItemAsync(sessionCart.CartID, foodItemId, comboId);
            }

            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = "Xóa sản phẩm khỏi giỏ hàng thành công."
            });
        }
        [HttpPost("checkout")]
        [Authorize]
        [ValidationFilter]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderDto>> CheckoutCart([FromBody] OrderForCreateDto orderForCreateDto)
        {
            OrderDto order;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            
            if (User.Identity.IsAuthenticated)
            {
                order = await _cartService.CheckoutCartAsync(userId, orderForCreateDto);
            }
            else
            {
                var sessionId = _sessionService.GetSessionId(HttpContext);
                order = await _cartService.CheckoutCartAsync(userId, orderForCreateDto);
                _sessionService.ClearSessionId(HttpContext);
            }

            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = "Đặt hàng thành công.",
                Data = order
            });
        }
        [HttpPost("clear")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ClearCart()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var userCart = await _cartService.GetOrCreateCartByUserAsync(userId);
                await _cartService.ClearCartAsync(userCart.CartID);
            }
            else
            {
                var sessionId = _sessionService.GetSessionId(HttpContext);
                var sessionCart = await _cartService.GetCartBySessionIdAsync(sessionId);
                await _cartService.ClearCartAsync(sessionCart.CartID);
            }

            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = "Xóa tất cả sản phẩm trong giỏ hàng thành công."
            });
        }
    }
}

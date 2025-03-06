using AsmC5.Common.Request;
using AsmC5.Common.Response;
using AsmC5.Contracts;
using AsmC5.DTOs.OrderDtos;
using AsmC5.Fillters;
using AsmC5.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Security.Claims;

namespace AsmC5.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrders([FromQuery] OrderRequestParameters parameters)
        {
            var (orders, metadata) = await _orderService.GetAllOrdersAsync(parameters);


            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = "Lấy danh sách đơn hàng thành công.",
                Data = orders,
                Pagination = metadata
            });
        }
        [HttpGet("{orderId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDto>> GetOrderById(int orderId)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = $"Lấy thông tin đơn hàng {orderId} thành công.",
                Data = order
            });
        }
        [HttpGet("user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersByUserId([FromQuery] OrderForUserRequestParameters orderForUserRequestParameters)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var orders = await _orderService.GetOrdersByUserIdAsync(userId, orderForUserRequestParameters);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = $"Lấy danh sách đơn hàng của người dùng {userId} thành công.",
                Data = orders
            });
        }
        [HttpGet("recent/{count:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetRecentOrders(int count)
        {
            var orders = await _orderService.GetRecentOrdersAsync(count);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = "Lấy danh sách đơn hàng gần đây thành công.",
                Data = orders
            });
        }
        [HttpGet("statistics/status")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Dictionary<OrderStatus, int>>> GetOrderStatusStatistics()
        {
            var statistics = await _orderService.GetOrderStatusStatisticsAsync();
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = "Lấy thống kê trạng thái đơn hàng thành công.",
                Data = statistics
            });
        }
        [HttpGet("date-range")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersByDateRange(
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            var orders = await _orderService.GetOrdersByDateRangeAsync(startDate, endDate);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = "Lấy danh sách đơn hàng theo khoảng thời gian thành công.",
                Data = orders
            });
        }
        [HttpPut("{orderId:int}/status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDto>> UpdateOrderStatus(int orderId, [FromBody] OrderForUpdate updateOrderStatus)
        {
            var order = await _orderService.UpdateOrderStatusAsync(orderId, updateOrderStatus.Status);
            return Ok(new ApiResponse<object>
            {
                StatusCode = 200,
                Success = true,
                Message = $"Cập nhật trạng thái đơn hàng {orderId} thành công.",
                Data = order
            });
        }
    }
}

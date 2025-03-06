using AsmC5.Common.Request;
using AsmC5.Contracts;
using AsmC5.DTOs.OrderDtos;
using AsmC5.Exceptions.NotFound.Exceptions.NotFound;
using AsmC5.Interfaces;
using AsmC5.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AsmC5.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly ILoggerService _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        public OrderService(
            IUnitOfWork unitOfWork,
            UserManager<ApplicationUser> userManager,
            IOrderRepository orderRepository,
            IMapper mapper,
            ILoggerService logger)
        {
            _userManager = userManager;
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<OrderDto> UpdateOrderStatusAsync(int orderId, OrderStatus status)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var order = await _orderRepository.GetByIdAsync(orderId);
                if (order == null)
                    throw new OrderNotFoundException($"Không tìm thấy đơn hàng {orderId}");

                


                // Gọi repository để cập nhật vào database
                await _orderRepository.UpdateOrderStatusAsync(orderId, status);

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();

                _logger.LogInfo($"Cập nhật trạng thái  đơn hàng {orderId} thành công");

                return _mapper.Map<OrderDto>(order);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                _logger.LogError($"Cập nhật trạng thái  đơn hàng {orderId} thất bại: {ex.Message}");
                throw;
            }
        }
        public async Task<OrderDto> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderByIdWithDetailsAsync(orderId, true);
            if (order == null)
                throw new OrderNotFoundException($"Không tìm thấy đơn hàng {orderId}");
            // Debug kiểm tra dữ liệu
            Console.WriteLine($"OrderID: {order.OrderID}");
            Console.WriteLine($"TotalAmount: {order.TotalAmount}");
            Console.WriteLine($"OrderDetails Count: {order.OrderDetails?.Count ?? 0}");
            if (order?.OrderDetails != null)
            {
                foreach (var detail in order.OrderDetails)
                {
                    Console.WriteLine($"OrderDetail ID: {detail.OrderDetailID}, FoodItemID: {detail.FoodItemID}, ComboID: {detail.ComboID}");
                }
            }
            return _mapper.Map<OrderDto>(order);
        }
        public async Task<IEnumerable<OrderDto>> GetOrdersByUserIdAsync(string userId, OrderForUserRequestParameters orderForUserRequestParameters)
        {
            var orders = await _orderRepository.GetOrdersByUserIdAsync(userId, orderForUserRequestParameters);
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<(IEnumerable<OrderDto> orders, MetaData metaData)> GetAllOrdersAsync(OrderRequestParameters parameters)
        {
            var orders = await _orderRepository.FetchAllOrderAsync(parameters);
            var orderDtos = _mapper.Map<List<OrderDto>>(orders);
            return (orders: orderDtos, metaData: orders.MetaData);
        }
        public async Task<Dictionary<OrderStatus, int>> GetOrderStatusStatisticsAsync()
        {
            return await _orderRepository.GetOrderStatusStatisticsAsync();
        }
        public async Task<IEnumerable<OrderDto>> GetRecentOrdersAsync(int count)
        {
            var orders = await _orderRepository.GetRecentOrdersAsync(count, true);
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }
        public async Task<IEnumerable<OrderDto>> GetOrdersByDateRangeAsync(
            DateTime startDate,
            DateTime endDate)
        {
            var orders = await _orderRepository.GetOrdersByDateRangeAsync(startDate, endDate, true);
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }
       
    }
}

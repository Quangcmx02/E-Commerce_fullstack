using AsmC5.DTOs.UserDtos;
using AsmC5.Models;
using System.ComponentModel.DataAnnotations;
using AsmC5.DTOs.OrderDetailDtos;
namespace AsmC5.DTOs.OrderDtos
{
    public class OrderDto
    {
        public int OrderID { get; set; }

        public DateTime OrderTime { get; set; }

        [Required]
        [MaxLength(50)]
        public OrderStatus Status { get; set; }

        [Range(0, 100000)]
        public decimal TotalAmount { get; set; }

        // Relationship
        public string UserID { get; set; }
        public UserDto User { get; set; }
        public ICollection<OrderDetailDto> OrderDetails { get; set; }
    }
}

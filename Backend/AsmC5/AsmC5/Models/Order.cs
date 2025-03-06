using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AsmC5.Models
{
    public enum OrderStatus
    {
        Pending ,      
        Shipping,
        AwaitingPayment,
        Delivered ,   
        Canceled      
    }
    public class Order
    {
        public int OrderID { get; set; }

        public DateTime OrderTime { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(20)")]
        public OrderStatus Status { get; set; }

        [Range(0, 100000)]
        public decimal TotalAmount { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        // Relationship
        public string UserID { get; set; }
        //public virtual ApplicationUser User { get; set; }
        public ApplicationUser User { get; set; }
    }
}

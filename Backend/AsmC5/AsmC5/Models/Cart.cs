using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AsmC5.Models
{
    public class Cart
    {
        public int CartID { get; set; }

        [Required]
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public string? SessionId { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace AsmC5.Models
{
    public class Combo
    {
        public int ComboID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [MaxLength(2000)]
        public string ImagePath { get; set; }
        public int? QuantityCombo { get; set; }
        public bool IsAvailable { get; set; }
        public virtual ICollection<ComboFoodItem> ComboFoodItems { get; set; } = new List<ComboFoodItem>();

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public virtual ICollection<CartItem>? CartItems { get; set; } = new List<CartItem>();
    }
}

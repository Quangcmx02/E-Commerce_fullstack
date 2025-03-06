using AsmC5.Models;
using System.ComponentModel.DataAnnotations;

namespace AsmC5.DTOs.CartItemDtos
{
    public class CartItemDto
    {
        [Required]
        public int CartID { get; set; }
        public virtual Cart Cart { get; set; }

        public int? FoodItemID { get; set; }

        public int QuantityFoodItem { get; set; }
        public int? ComboID { get; set; }
        public int? QuantityCombo { get; set; }

        public decimal Price { get; set; }
    }
}

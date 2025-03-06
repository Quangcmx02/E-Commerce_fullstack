using System.ComponentModel.DataAnnotations;

namespace AsmC5.DTOs.CartItemDtos
{
    public class CartItemForUpdateDto
    {
        public int? FoodItemID { get; set; }
        public int? QuantityFoodItem { get; set; }
        public int? ComboID { get; set; }
        public int? QuantityCombo { get; set; }
    }
}

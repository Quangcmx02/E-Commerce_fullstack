using AsmC5.DTOs.ComboDtos;
using AsmC5.DTOs.FoodItemDtos;
using AsmC5.Models;
using System.ComponentModel.DataAnnotations;

namespace AsmC5.DTOs.OrderDetailDtos
{
    public class OrderDetailDto
    {
        public int OrderDetailID { get; set; }
        [Range(1, 100)]
        public int? QuantityFoodItem { get; set; }

        [Range(1, 100)]
        public int? QuantityCombo { get; set; }

        [Range(0, 100000)]
        public decimal Price { get; set; }

        // Relationship
        public int OrderID { get; set; }
        public int? FoodItemID { get; set; }
        public int? ComboID { get; set; }
        public FoodItemDto FoodItem { get; set; }
        public ComboDto Combo { get; set; }
    }
}

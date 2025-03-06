using System.ComponentModel.DataAnnotations;
using AsmC5.Models;

namespace AsmC5.DTOs.CartItemDtos
{
    public class CartItemForCreateDto
    {



        public int? FoodItemID { get; set; }

        public int QuantityFoodItem { get; set; }
        public int? ComboID { get; set; }
        public int QuantityCombo { get; set; }

    }
}

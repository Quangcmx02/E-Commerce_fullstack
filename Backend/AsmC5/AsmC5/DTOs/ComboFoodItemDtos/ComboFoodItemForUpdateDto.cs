using AsmC5.DTOs.ComboDtos;
using AsmC5.DTOs.FoodItemDtos;
using AsmC5.Models;

namespace AsmC5.DTOs.ComboFoodItemDtos
{
    public class ComboFoodItemForUpdateDto
    {
        public int ComboFoodItemID { get; set; }
        public int FoodItemID { get; set; }
        public FoodItemDto FoodItemDtos { get; set; }

        public int ComboID { get; set; }

    }
}

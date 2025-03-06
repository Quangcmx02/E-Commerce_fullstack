using AsmC5.DTOs.ComboFoodItemDtos;
using AsmC5.Models;

namespace AsmC5.DTOs.ComboFoodDetailsDtos
{
    public class COmboFoodItemDetailsFOrUpdateDto
    {
        public int ComboFoodItemDetailId { get; set; }
        public int QuantityFoodInCombo { get; set; }
        public int ComboFoodItemId { get; set; }
        public ICollection<ComboFoodItemForUpdateDto> ComboFoodItemForUpdateDto { get; set; }
    }
}

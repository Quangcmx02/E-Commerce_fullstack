using AsmC5.DTOs.ComboFoodItemDtos;
using AsmC5.Models;

namespace AsmC5.DTOs.ComboFoodDetailsDtos
{
    public class COmboFoodItemDetailsFOrCreateDto
    {

        public int QuantityFoodInCombo { get; set; }
        public int ComboFoodItemId { get; set; }
        public ICollection<ComboFoodItemForCreateDto> ComboFoodItemForCreateDto { get; set; }
    }
}

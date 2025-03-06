using AsmC5.DTOs.CategoryDtos;
using AsmC5.DTOs.ComboFoodItemDtos;
using System.ComponentModel.DataAnnotations;
using AsmC5.DTOs.ComboFoodDetailsDtos;

namespace AsmC5.DTOs.ComboDtos
{
    public class ComboDto
    {
        public int ComboID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [MaxLength(2000)]
        public string ImagePath { get; set; }
        public int? QuantityCombo { get; set; }
        public bool IsAvailable { get; set; }
        public List<ComboFoodItemViewDto> ComboFoodItemViews { get; set; } = new List<ComboFoodItemViewDto>();
        public List<ComboFoodItemDetailsFto> ComboFoodItemDetailsFtos { get; set; } = new List<ComboFoodItemDetailsFto>();


    }
}

using System.ComponentModel.DataAnnotations;
using AsmC5.DTOs.ComboFoodDetailsDtos;
using AsmC5.DTOs.ComboFoodItemDtos;

namespace AsmC5.DTOs.ComboDtos
{
    public class ComboForCreateDto
    {


        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [MaxLength(2000)]
        public string ImagePath { get; set; }

        public bool IsAvailable { get; set; }
        public ICollection<COmboFoodItemDetailsFOrCreateDto> COmboFoodItemDetailsFOrCreateDtos { get; set; }
        public ICollection<ComboFoodItemForCreateDto> ComboFoodItemForCreateDto { get; set; }

    }
}

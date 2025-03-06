using AsmC5.DTOs.CategoryDtos;
using AsmC5.Models;
using System.ComponentModel.DataAnnotations;

namespace AsmC5.DTOs.FoodItemDtos
{
    public class FoodItemForCreateDto
    {
      

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public string? Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        [MaxLength(5000)]
        public string ImagePath { get; set; }
        [Required]
        // Relationship
        public int CategoryID { get; set; }
        public CategoryDto Category { get; set; }
    }
}


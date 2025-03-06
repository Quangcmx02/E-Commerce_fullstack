using AsmC5.Models;
using System.ComponentModel.DataAnnotations;
using AsmC5.DTOs.CategoryDtos;
namespace AsmC5.DTOs.FoodItemDtos
{
    public class FoodItemDto
    {
        public int FoodItemId { get; set; }


        public string Name { get; set; }

        public string? Description { get; set; }


        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }


        public string ImagePath { get; set; }


        public CategoryDto Category { get; set; }
    }
}

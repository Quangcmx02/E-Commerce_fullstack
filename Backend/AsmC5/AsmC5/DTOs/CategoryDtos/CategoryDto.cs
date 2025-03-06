using System.ComponentModel.DataAnnotations;

namespace AsmC5.DTOs.CategoryDtos
{
    public class CategoryDto
    {
        public int CategoryID { get; set; }

  
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

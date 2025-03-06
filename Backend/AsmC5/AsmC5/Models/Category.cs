using System.ComponentModel.DataAnnotations;

namespace AsmC5.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

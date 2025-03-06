using System.ComponentModel.DataAnnotations;

namespace AsmC5.Models
{
    public class FoodItem
    {
        public int  FoodItemId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }
        [Required]
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }

        [MaxLength(5000)]
        public string ImagePath { get; set; }

        // Relationship
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}

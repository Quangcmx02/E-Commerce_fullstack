using static Azure.Core.HttpHeader;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsmC5.Models
{
    public class CartItem
    {
        public int CartItemID { get; set; }

        [Required]
        public int CartID { get; set; }
        public virtual Cart Cart { get; set; }

        public int? FoodItemID { get; set; }
        public virtual FoodItem? FoodItem { get; set; }
    
        public int? QuantityFoodItem { get; set; }
        
        public int? ComboID { get; set; }
        [ForeignKey("ComboID")]
        public virtual Combo? Combo { get; set; }

       
        public int? QuantityCombo { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than or equal to 0.")]
        public decimal Price { get; set; }
    }
}

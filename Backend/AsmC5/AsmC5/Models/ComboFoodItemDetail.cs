namespace AsmC5.Models
{
    public class ComboFoodItemDetail
    {
        public int ComboFoodItemDetailId { get; set; }
        public int QuantityFoodInCombo { get; set; }
        public int ComboFoodItemId { get; set; }
        public virtual ComboFoodItem ComboFoodItems { get; set; } = null!;
      
    }
}

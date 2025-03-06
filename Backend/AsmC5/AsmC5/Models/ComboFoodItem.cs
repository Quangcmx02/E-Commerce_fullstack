namespace AsmC5.Models
{
    public class ComboFoodItem
    {

        public int ComboFoodItemID { get; set; }
        public int FoodItemID { get; set; }
        public virtual FoodItem FoodItem { get; set; }
       
        public int ComboID { get; set; }
        public virtual Combo Combo { get; set; }
        public virtual ICollection<ComboFoodItemDetail> ComboFoodItemDetails { get; set; } = new List<ComboFoodItemDetail>();


    }
}

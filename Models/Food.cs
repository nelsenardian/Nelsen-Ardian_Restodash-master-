namespace RestoDash.Models
{
    /// <summary>
    /// Model class for defining the food object data.
    /// </summary>
    public class Food
    {
        /// <summary>
        /// Gets or sets the food ID.
        /// </summary>
        public int FoodId { get; set; }

        /// <summary>
        /// Gets or sets the food name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the required ingredient requirements in order to make this food.
        /// </summary>
        public List<IngredientRequirement> IngredientRequirements { get; set; } = new List<IngredientRequirement>();

        /// <summary>
        /// Gets or sets the food's price.
        /// </summary>
        public decimal Price { get; set; }
    }
}

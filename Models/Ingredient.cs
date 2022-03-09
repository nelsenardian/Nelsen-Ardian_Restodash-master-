namespace RestoDash.Models
{
    /// <summary>
    /// Model class for defining the ingredient object data.
    /// </summary>
    public class Ingredient
    {
        /// <summary>
        /// Gets or sets the ingredient ID.
        /// </summary>
        public int IngredientId { get; set; }

        /// <summary>
        /// Gets or sets the ingredient name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ingredient quantity.
        /// </summary>
        public int Qty { get; set; }
    }
}

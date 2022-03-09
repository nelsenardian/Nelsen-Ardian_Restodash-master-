using RestoDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoDash.Data
{
    /// <summary>
    /// Static class for providing static ingredient data.
    /// </summary>
    public static class IngredientMenu
    {
        /// <summary>
        /// Gets or sets the static ingredient data.
        /// </summary>
        public static List<Ingredient> Ingredients { get; set; } = new List<Ingredient>
        {
            new Ingredient
            {
                IngredientId = 1,
                Name = "Egg",
                Qty = 12
            },
            new Ingredient
            {
                IngredientId = 2,
                Name = "Tomato",
                Qty = 10
            },
            new Ingredient
            {
                IngredientId = 3,
                Name = "Mineral Water",
                Qty = 24
            }
        };
    }
}

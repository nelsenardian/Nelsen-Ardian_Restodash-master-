using RestoDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoDash.Data
{
    /// <summary>
    /// Static class for providing static food data.
    /// </summary>
    public static class FoodMenu
    {
        /// <summary>
        /// Gets or sets the static food data.
        /// </summary>
        public static List<Food> Foods { get; set; } = new List<Food> 
        {
            new Food
            {
                FoodId = 1,
                Name = "Tomato Omelette",
                IngredientRequirements = new List<IngredientRequirement>
                {
                    new IngredientRequirement
                    {
                        IngredientId = 1,
                        Qty = 2
                    },
                    new IngredientRequirement
                    {
                        IngredientId = 2,
                        Qty = 1
                    }
                },
                Price = 20_000
            },
            new Food
            {
                FoodId = 2,
                Name = "Water",
                IngredientRequirements = new List<IngredientRequirement>
                {
                    new IngredientRequirement
                    {
                        IngredientId = 3,
                        Qty = 1
                    }
                },
                Price = 2_000
            },
        };
    }
}

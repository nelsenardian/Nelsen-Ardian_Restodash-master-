using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoDash.Models
{
    /// <summary>
    /// Model class for defining the ingredient requirement object data.
    /// </summary>
    public class IngredientRequirement
    {
        /// <summary>
        /// Gets or sets the ingredient ID.
        /// </summary>
        public int IngredientId { get; set; }

        /// <summary>
        /// Gets or sets the required quantity.
        /// </summary>
        public int Qty { get; set; }
    }
}

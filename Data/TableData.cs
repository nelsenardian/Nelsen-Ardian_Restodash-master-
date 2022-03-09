using RestoDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoDash.Data
{
    /// <summary>
    /// Static class for providing static table data.
    /// </summary>
    public static class TableData
    {
        /// <summary>
        /// Gets or sets the static table data.
        /// </summary>
        public static Table Table { get; set; } = new Table();
    }
}

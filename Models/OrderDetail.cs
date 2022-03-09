using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoDash.Models
{
    public class OrderDetail
    {
        public Guid OrderDetailId { get; set; }
         public int? FoodId { get; set; }
         public string FoodName { get; set; } = string.Empty;
          public decimal FoodPrice { get; set; } 
    }
}

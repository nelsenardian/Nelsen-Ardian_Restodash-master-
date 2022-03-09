using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoDash.Models
{
    internal class Order
    {
        public string CustomerName { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public DateTimeOffset OrderedAt { get; set; }  
        public DateTimeOffset KickedAt { get; set; }
}
}

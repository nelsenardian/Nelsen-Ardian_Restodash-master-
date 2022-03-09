using RestoDash.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoDash.Models
{
    public class Seat
    {
        public int SeatNumber { get; set; }

        public SeatPosition Position { get; set; }

        public int? OrderId { get; set; }
    }
}

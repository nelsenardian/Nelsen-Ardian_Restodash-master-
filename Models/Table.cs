using RestoDash.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoDash.Models
{
    public class Table
    {
        public int TableNumber { get; set; }

        public Table()
        {
            for (int i = 0; i < 4; i++)
            {
                Seats.Add(new Seat
                {
                    SeatNumber = i + 1,
                    Position = (SeatPosition)i
                });
            }
        }

        public List<Seat> Seats { get; set; } = new List<Seat>();
    }
}

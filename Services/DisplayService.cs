using RestoDash.Data;
using RestoDash.Enums;
using RestoDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoDash.Services
{
    /// <summary>
    /// Provides various methods to display the application's outputs.
    /// </summary>
    public class DisplayService
    {
        public void DisplayMenu()
        {
            var menuText = @"Menu:
1. Maintain Ingredient
2. Maintain Food
3. Accept Order
0. Exit
Please choose your choice [0..4]:";

            Console.WriteLine(menuText);
        }

        /// <summary>
        /// Display the table.
        /// </summary>
        public void DisplayTable()
        {
            var table = new Table();
            var topSeatDisplay = "   ";
            var hasTopSeat = table.Seats
                .Exists(Q => Q.Position == SeatPosition.Top);
            if (hasTopSeat)
            {
                topSeatDisplay = " X ";
            }
            Console.WriteLine(topSeatDisplay);

            var hasLeftSeat = table.Seats
                .Exists(Q => Q.Position == SeatPosition.Left);
            if (hasLeftSeat)
            {
                Console.Write("X");
            }

            // Display the table as O.
            Console.Write("O");

            var hasRightSeat = table.Seats
                .Exists(Q => Q.Position == SeatPosition.Right);
            if (hasRightSeat)
            {
                Console.WriteLine("X");
            }

            var bottomSeatDisplay = "   ";
            var hasBottomSeat = table.Seats
                .Exists(Q => Q.Position == SeatPosition.Bottom);
            if (hasBottomSeat)
            {
                bottomSeatDisplay = " X ";
            }
            Console.WriteLine(bottomSeatDisplay);

            TableData.Table = table;

            Console.WriteLine("==============================================");
        }
    }
}

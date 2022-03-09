using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoDash.Services
{
    internal class ViewOrders
    {
        /// <summary>
        /// Display the maintenance menu.
        /// </summary>
        public void DisplayMenu()
        {
            Console.Clear();


            var isExitOption = false;
            while (isExitOption == false)
            {
                DisplayMenuOption();
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ServeCustomer();
                        break;
                    case "2":
                        KickCustomer();
                        break;
                    case "0":
                        isExitOption = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.");
                        Console.ReadLine();
                        break;
                }

                Console.Clear();
            }
        }

        /// <summary>
        /// Display the menu options.
        /// </summary>
        public void DisplayMenuOption()
        {
            var menuText = @"Accept Order Menu:
1. Serve customer
2. Kick customer
0. Exit
Please choose your choice [0..2]:";

            Console.WriteLine(menuText);
        }
    }
}

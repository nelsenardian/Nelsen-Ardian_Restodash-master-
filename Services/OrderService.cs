using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestoDash.Data;
using RestoDash.Models;

namespace RestoDash.Services
{
    public class OrderService
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


        /// <summary>
        /// Display the serve customer menu
        /// </summary>
        public void ServeCustomer()
        {
            var customerName = ValidateCustomerName();
            var foodID = ValidateFoodID();
            var orderID = ValidateOrderID();


            var seat = new Seat();
            if(seat.OrderId.ToString() == null)
            {
                Console.WriteLine("");
            } else
            {
                Console.WriteLine("There are no available seats for now, please come back later");
            }
        }


        public void KickCustomer() { }



        public string ValidateCustomerName()
        {
            var isValidCustomerName = false;
            var customerName = string.Empty;
            while (isValidCustomerName == false)
            {
                Console.WriteLine("Please input your name:");
                customerName = Console.ReadLine();

                if (string.IsNullOrEmpty(customerName) == true)
                {
                    Console.WriteLine("Name cannot be empty.");
                }
                else
                {
                    isValidCustomerName = true;
                }
            }

            return customerName!;
        }

        public int ValidateFoodID()
        {
            var isValidFoodId = false;
            var foodId = 0;
            while (isValidFoodId == false)
            {
                Console.WriteLine("Please input your food Id:");
                var isfoodInt = int.TryParse(Console.ReadLine(), out var inputFoodId);

                if (isfoodInt == true)
                {
                    Console.WriteLine("food cannot be empty.");
                }
                else
                {
                    var isExistingFood = FoodMenu.Foods
                        .Exists(Q => Q.FoodId == inputFoodId);

                    if (isExistingFood == false)
                    {
                        Console.WriteLine("Food ID is not found, Please input a valid food Id");
                    }
                    else
                    {
                        foodId = inputFoodId;
                        isValidFoodId = true;
                    }
                }
            }

            return foodId;
        }

        public int ValidateOrderID() { 
            
        }
     


    }
}

using RestoDash.Data;
using RestoDash.Models;


namespace RestoDash.Services
{
    /// <summary>
    /// Store various methods for handling ingredient menu data maintenance requests.
    /// </summary>
    public class IngredientMenuService
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
                DisplayExistingIngredients();
                DisplayMenuOptions();

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddNewIngridient();
                        break;
                    case "2":
                        EditIngredient();
                        break;
                    case "3":
                        DeleteIngredient();
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
        public void DisplayMenuOptions()
        {
            var menuText = @"Maintain Ingredient Menu:
1. Add ingredient
2. Edit ingredient
3. Delete ingredient
0. Exit
Please choose your choice [0..3]:";

            Console.WriteLine(menuText);
        }

        /// <summary>
        /// Display the existing registered foods.
        /// </summary>
        public void DisplayExistingIngredients()
        {
            Console.WriteLine("Registered Ingredients:");
            var index = 1;
            Console.WriteLine("| No. | Name | Quantity| Ingredient ID |");


            if (IngredientMenu.Ingredients.Count > 0)
            {
                foreach (var ingredient in IngredientMenu.Ingredients)
                {
                    Console.WriteLine($"| {index} | {ingredient.Name} | { ingredient.Qty} | {ingredient.IngredientId} |");

                    index++;
                }
            }
            else
            {
                Console.WriteLine("No data available.");
            }
                Console.WriteLine("=================================");
        }

        /// <summary>
        /// Add new ingredient based on the user inputs.
        /// </summary>
        public void AddNewIngridient()
        {
            var ingredientName = ValidateIngredientName();
            var ingredientQty = ValidateIngredientQty();

            var latestIngredientId = IngredientMenu.Ingredients.Max(Q => Q.IngredientId);
            IngredientMenu.Ingredients.Add(new Ingredient
            {
                IngredientId = latestIngredientId + 1,
                Name = ingredientName,
                Qty = (int)ingredientQty,

            });
        }

        /// <summary>
        /// Edit the existing ingredient based on the user inputs.
        /// </summary>
        public void EditIngredient()
        {
            if (IngredientMenu.Ingredients.Count == 0)
            {
                DisplayContinueMessage(@"No data available.
Press any key to continue....");
                return;
            }

            var ingredientId = ValidateIngredientId();
            var ingredientName = ValidateIngredientName();
            var ingredientQty = ValidateIngredientQty();


            // Should be never null after we have validate the ingredient ID.
            var ingredient = IngredientMenu.Ingredients
                .FirstOrDefault(Q => Q.IngredientId == ingredientId)!;

            ingredient.Name = ingredientName;
            ingredient.Qty = (int)ingredientQty;

            DisplayContinueMessage(@"Edit success!
Press any key to continue....");
        }

        /// <summary>
        /// Delete the existing ingredient based on the user inputs.
        /// </summary>
        public void DeleteIngredient()
        {
            if (IngredientMenu.Ingredients.Count == 0)
            {
                DisplayContinueMessage(@"No data available.
Press any key to continue....");
                return;
            }

            var ingredientId = ValidateIngredientId();

            // Should be never null after we have validate the ingridientID.
            var ingredient = IngredientMenu.Ingredients
                .FirstOrDefault(Q => Q.IngredientId == ingredientId)!;

            Console.WriteLine($"Are you sure you want to delete [{ingredient.Name}]?(Y/n)");
            var confirmOption = Console.ReadLine();

            if (string.IsNullOrEmpty(confirmOption) || confirmOption.ToLower() != "y")
            {
                DisplayContinueMessage(@"Cancelling deletion process....
Press any key to continue....");
                return;
            }

            IngredientMenu.Ingredients.Remove(ingredient);
            DisplayContinueMessage(@"Deletion success!
Press any key to continue....");
        }


        /// <summary>
        /// Validate the ingredient ID input data.
        /// </summary>
        /// <returns></returns>
        public int ValidateIngredientId()
        {
            var isValidIngredientId = false;
            var ingredientId = 0;
            while (isValidIngredientId == false)
            {
                Console.WriteLine("Please choose your ingredient ID:");
                var isIngredientIdInt = int.TryParse(Console.ReadLine(), out var inputIngredientId);

                if (isIngredientIdInt == false)
                {
                    Console.WriteLine("Invalid ingredient ID. Please input a valid integer value.");
                }
                else
                {
                    var isExistingIngredient = IngredientMenu.Ingredients
                        .Exists(Q => Q.IngredientId == inputIngredientId);

                    if (isExistingIngredient == false)
                    {
                        Console.WriteLine("Ingredient ID not found. Please input a valid food ID.");
                    }
                    else
                    {
                        ingredientId = inputIngredientId;
                        isValidIngredientId = true;
                    }
                }
            }

            return ingredientId;
        }

        /// <summary>
        /// Validate the food name input data.
        /// </summary>
        /// <returns></returns>
        public string ValidateIngredientName()
        {
            var isValidIngredientName = false;
            var ingredientName = string.Empty;
            while (isValidIngredientName == false)
            {
                Console.WriteLine("Please input your food name:");
                ingredientName = Console.ReadLine();

                if (string.IsNullOrEmpty(ingredientName) == true)
                {
                    Console.WriteLine("ingredient name cannot be empty.");
                }
                else if (ingredientName.Length < 4)
                {
                    Console.WriteLine("Food name minimum length must be at least 4 characters.");
                }
                else
                {
                    isValidIngredientName = true;
                }
            }
            return ingredientName!;
        }

        /// <summary>
        /// Validate the ingredient qty input data.
        /// </summary>
        /// <returns></returns>
        public int ValidateIngredientQty()
        {
            var isValidIngredientQty = false;
            var ingredientQty = 0;


            while (isValidIngredientQty == false)
            {
                Console.WriteLine("Please input ingredient Qty:");
                var isIngredientQty = int.TryParse(Console.ReadLine(), out var inputQty);

                if (isIngredientQty == false)
                {
                    Console.WriteLine("Invalid qty input. Please input a valid int value.");
                }
                else
                {
                    if (inputQty <= 100 && inputQty < 0)
                    {
                        Console.WriteLine("Integer qty cannot be more than 100 and less than 0.");
                    }
                    else
                    {
                        ingredientQty = inputQty;
                        isValidIngredientQty = true;
                    }
                }
            }

            return ingredientQty;
        }


        /// <summary>
        /// Display the registered ingredient data.
        /// </summary>
        public void DisplayRegisteredIngredients()
        {
            Console.WriteLine("Registered Ingredients:");
            var registeredIngredientIndex = 1;
            Console.WriteLine("| No. | Name | Qty | Ingredient ID |");
            foreach (var ingredient in IngredientMenu.Ingredients)
            {
                Console.WriteLine($"| {registeredIngredientIndex} | {ingredient.Name} | { ingredient.Qty } | {ingredient.IngredientId } |");

                registeredIngredientIndex++;
            }
        }

        /// <summary>
        /// Display the continue prompt messages.
        /// </summary>
        /// <param name="message"></param>
        public void DisplayContinueMessage(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
        }
    }
}

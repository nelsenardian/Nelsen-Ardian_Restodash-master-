using RestoDash.Data;
using RestoDash.Models;

namespace RestoDash.Services
{
    /// <summary>
    /// Store various methods for handling food menu data maintenance requests.
    /// </summary>
    public class FoodMenuService
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
                DisplayExistingFoods();
                DisplayMenuOptions();
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddNewFood();
                        break;
                    case "2":
                        DisplayFoodRequiredIngredients();
                        break;
                    case "3":
                        EditFood();
                        break;
                    case "4":
                        DeleteFood();
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
            var menuText = @"Maintain Food Menu:
1. Add food
2. View required ingredients
3. Edit food
4. Delete food
0. Exit
Please choose your choice [0..4]:";

            Console.WriteLine(menuText);
        }

        /// <summary>
        /// Display the existing registered foods.
        /// </summary>
        public void DisplayExistingFoods()
        {
            Console.WriteLine("Registered Foods:");
            var index = 1;
            Console.WriteLine("| No. | Name | Price | Food ID |");

            if (FoodMenu.Foods.Count > 0)
            {
                foreach (var food in FoodMenu.Foods)
                {
                    Console.WriteLine($"| {index} | {food.Name} | { food.Price } | {food.FoodId} |");

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
        /// Add new food based on the user inputs.
        /// </summary>
        public void AddNewFood()
        {
            var foodName = ValidateFoodName();
            var foodPrice = ValidateFoodPrice();
            var ingredients = ValidateFoodIngredients();

            var latestFoodId = FoodMenu.Foods.Max(Q => Q.FoodId);
            FoodMenu.Foods.Add(new Food
            {
                FoodId = latestFoodId + 1,
                Name = foodName,
                Price = foodPrice,
                IngredientRequirements = ingredients
            });
        }

        /// <summary>
        /// Edit the existing food based on the user inputs.
        /// </summary>
        public void EditFood()
        {
            if (FoodMenu.Foods.Count == 0)
            {
                DisplayContinueMessage(@"No data available.
Press any key to continue....");
                return;
            }

            var foodId = ValidateFoodId();
            var foodName = ValidateFoodName();
            var foodPrice = ValidateFoodPrice();
            var ingredients = ValidateFoodIngredients();

            // Should be never null after we have validate the food ID.
            var food = FoodMenu.Foods
                .FirstOrDefault(Q => Q.FoodId == foodId)!;

            food.Name = foodName;
            food.Price = foodPrice;
            food.IngredientRequirements = ingredients;

            DisplayContinueMessage(@"Edit success!
Press any key to continue....");
        }

        /// <summary>
        /// Delete the existing food based on the user inputs.
        /// </summary>
        public void DeleteFood()
        {
            if (FoodMenu.Foods.Count == 0)
            {
                DisplayContinueMessage(@"No data available.
Press any key to continue....");
                return;
            }

            var foodId = ValidateFoodId();

            // Should be never null after we have validate the food ID.
            var food = FoodMenu.Foods
                .FirstOrDefault(Q => Q.FoodId == foodId)!;

            Console.WriteLine($"Are you sure you want to delete [{food.Name}]?(Y/n)");
            var confirmOption = Console.ReadLine();

            if (string.IsNullOrEmpty(confirmOption) || confirmOption.ToLower() != "y")
            {
                DisplayContinueMessage(@"Cancelling deletion process....
Press any key to continue....");
                return;
            }

            FoodMenu.Foods.Remove(food);
            DisplayContinueMessage(@"Deletion success!
Press any key to continue....");
        }

        /// <summary>
        /// Validate the food name input data.
        /// </summary>
        /// <returns></returns>
        public string ValidateFoodName()
        {
            var isValidFoodName = false;
            var foodName = string.Empty;
            while (isValidFoodName == false)
            {
                Console.WriteLine("Please input your food name:");
                foodName = Console.ReadLine();

                if (string.IsNullOrEmpty(foodName) == true)
                {
                    Console.WriteLine("Food name cannot be empty.");
                }
                else if (foodName.Length < 3)
                {
                    Console.WriteLine("Food name minimum length must be at least 3 characters.");
                }
                else
                {
                    isValidFoodName = true;
                }
            }

            return foodName!;
        }

        /// <summary>
        /// Validate the food price input data.
        /// </summary>
        /// <returns></returns>
        public decimal ValidateFoodPrice()
        {
            var isValidFoodPrice = false;
            var foodPrice = 0M;
            while (isValidFoodPrice == false)
            {
                Console.WriteLine("Please input your food price:");
                var isPriceDecimal = decimal.TryParse(Console.ReadLine(), out var inputPrice);

                if (isPriceDecimal == false)
                {
                    Console.WriteLine("Invalid price input. Please input a valid decimal value.");
                }
                else
                {
                    if (inputPrice <= 100)
                    {
                        Console.WriteLine("Food price cannot be less and equal than 100.");
                    }
                    else
                    {
                        foodPrice = inputPrice;
                        isValidFoodPrice = true;
                    }
                }
            }

            return foodPrice;
        }

        /// <summary>
        /// Validate the food ingredients input data.
        /// </summary>
        /// <returns></returns>
        public List<IngredientRequirement> ValidateFoodIngredients()
        {
            var isValidFoodIngredients = false;
            var foodIngredients = new List<IngredientRequirement>();
            while (isValidFoodIngredients == false)
            {
                DisplayRegisteredIngredients();
                DisplayCurrentRegisteredFoodIngredients(foodIngredients);
                var ingredientId = ValidateFoodIngredientId();
                var ingredientQty = ValidateFoodIngredientQty();

                // Check whether the newly added required ingredient
                // has been added into this new food's required ingredient.
                var previouslyAddedIngredient = foodIngredients
                    .FirstOrDefault(Q => Q.IngredientId == ingredientId);

                // If exists, then just update quantity.
                if (previouslyAddedIngredient != null)
                {
                    previouslyAddedIngredient.Qty += ingredientQty;
                }
                // If not exists, then register this new required ingredient.
                else
                {
                    foodIngredients.Add(new IngredientRequirement
                    {
                        IngredientId = ingredientId,
                        Qty = ingredientQty
                    });
                }

                Console.WriteLine("Continue add ingredient requirement?(Y/n)");

                var continueOption = Console.ReadLine();

                // If user didn't input Y/y value, then it will finish
                // the add ingredient requirement process.
                if (string.IsNullOrEmpty(continueOption) || continueOption.ToLower() != "y")
                {
                    isValidFoodIngredients = true;
                }
            }

            return foodIngredients;
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
        /// Display the registered food ingredients
        /// for this currently added food data.
        /// </summary>
        public void DisplayCurrentRegisteredFoodIngredients(List<IngredientRequirement> foodIngredients)
        {
            Console.WriteLine("Current Registered Required Ingredients:");
            Console.WriteLine("| Ingredient ID | Qty |");
            foreach (var ingredient in foodIngredients)
            {
                Console.WriteLine($"| { ingredient.IngredientId } | { ingredient.Qty } |");
            }
        }

        /// <summary>
        /// Display the food's required ingredient data.
        /// </summary>
        /// <param name="foodId"></param>
        public void DisplayFoodRequiredIngredients(int foodId)
        {
            var food = FoodMenu.Foods
                .FirstOrDefault(Q => Q.FoodId == foodId);

            if (food == null)
            {
                Console.WriteLine("Food was not found....");
                Console.WriteLine("Press any key to continue....");
                Console.ReadLine();
                return;
            }

            var query = from i in IngredientMenu.Ingredients
                        join fir in food.IngredientRequirements on i.IngredientId equals fir.IngredientId
                        select new
                        {
                            i.IngredientId,
                            IngredientName = i.Name,
                            RequiredQty = fir.Qty,
                            i.Qty
                        };

            var requiredIngredients = query.ToList();

            Console.WriteLine("Current Registered Required Ingredients:");
            Console.WriteLine("| Ingredient ID | Name | Required Qty | Qty |");
            foreach (var ingredient in requiredIngredients)
            {
                Console.WriteLine($"| { ingredient.IngredientId } | {ingredient.IngredientName} | { ingredient.RequiredQty } | { ingredient.Qty } |");
            }
        }

        /// <summary>
        /// Validate the food ingredient ID input data.
        /// </summary>
        /// <returns></returns>
        public int ValidateFoodIngredientId()
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
                        Console.WriteLine("Ingredient ID not found. Please input a valid ingredient ID.");
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
        /// Validate the food ingredient quantity input data.
        /// </summary>
        /// <returns></returns>
        public int ValidateFoodIngredientQty()
        {
            var isValidIngredientQty = false;
            var ingredientQty = 0;
            while (isValidIngredientQty == false)
            {
                Console.WriteLine("Please input your ingredient required quantity:");
                var isQtyInt = int.TryParse(Console.ReadLine(), out var inputQty);

                if (isQtyInt == false)
                {
                    Console.WriteLine("Invalid quantity input. Please input a valid integer value.");
                }
                else
                {
                    if (inputQty < 1)
                    {
                        Console.WriteLine("Quantity must be higher than 0.");
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
        /// Validate the food ID input data.
        /// </summary>
        /// <returns></returns>
        public int ValidateFoodId()
        {
            var isValidFoodId = false;
            var foodId = 0;
            while (isValidFoodId == false)
            {
                Console.WriteLine("Please choose your food ID:");
                var isFoodIdInt = int.TryParse(Console.ReadLine(), out var inputFoodId);

                if (isFoodIdInt == false)
                {
                    Console.WriteLine("Invalid food ID. Please input a valid integer value.");
                }
                else
                {
                    var isExistingFood = FoodMenu.Foods
                        .Exists(Q => Q.FoodId == inputFoodId);

                    if (isExistingFood == false)
                    {
                        Console.WriteLine("Food ID not found. Please input a valid food ID.");
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

        /// <summary>
        /// Display the food's required ingredients menu.
        /// </summary>
        public void DisplayFoodRequiredIngredients()
        {
            var foodId = ValidateFoodId();

            DisplayFoodRequiredIngredients(foodId);

            Console.WriteLine("Press any key to continue....");
            Console.ReadLine();
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

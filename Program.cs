using RestoDash.Services;

var displayService = new DisplayService();
var foodMenuService = new FoodMenuService();
var ingredientMenuService = new IngredientMenuService();
var orderService = new OrderService();

var isExitOption = false;
while (isExitOption == false)
{
    displayService.DisplayTable();
    displayService.DisplayMenu();
    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            ingredientMenuService.DisplayMenu();
            break;
        case "2":
            foodMenuService.DisplayMenu();
            break;
        case "3":
            orderService.DisplayMenu();
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

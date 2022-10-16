namespace Coffee_Shop_POS_Project;

class Program
{
    public static void Main(string[] args)
    {
        Product productChoice;

        Console.WriteLine("What are you adding?: \n1: Drink \n2: Food");
        int userChoice = Convert.ToInt32(Console.ReadLine());

        if (userChoice == 1) productChoice = GetCustomerDrinks();
        else productChoice = GetCustomerFood();

        Console.WriteLine(productChoice);
    }

    static Product GetCustomerDrinks()
    {
        // Variable
        var availableDrinks = Menu.DrinksAvailable;
        string userInput = "";

        // Prompt user for drink category
        for (int i = 0; i < availableDrinks.GroupsCollection.Count; i++) userInput += $"\n{i} : {availableDrinks.GroupsCollection[i].GroupName}";
        Console.WriteLine("What type of drink would you like to add?" + userInput);
        int chosenCategory = Convert.ToInt32(Console.ReadLine());
        userInput = ""; //Reset userInput

        // Prompt user for specific drink within that category
        for (int i = 0; i < availableDrinks.GroupsCollection[chosenCategory].DrinksCollection.Count; i++) userInput += $"\n{i} : {availableDrinks.GroupsCollection[chosenCategory].DrinksCollection[i].ItemName}";
        Console.WriteLine("What drinks would you like to add?" + userInput);
        int chosenDrink = Convert.ToInt32(Console.ReadLine());

        // Prompt user for drink size and assigns relevant drinkSize
        Console.WriteLine("What's the size of your drink? \n0 : Small\n1 : Medium\n2 : Large");
        int sizeInput = Convert.ToInt32(Console.ReadLine());
        var drinkSize = sizeInput switch // Select size enum based on userInput
        {
            0 => DrinkSizes.Small,
            1 => DrinkSizes.Medium,
            2 => DrinkSizes.Large,
            _ => throw new ArgumentOutOfRangeException()
        };

        var itemName = availableDrinks.GroupsCollection[chosenCategory].DrinksCollection[chosenDrink].ItemName;
        var price = availableDrinks.GroupsCollection[chosenCategory].DrinksCollection[chosenDrink].Price[(int) drinkSize];
        var category = availableDrinks.GroupsCollection[chosenCategory].GroupName;
        return new Product(drinkSize, itemName, price, category);
    }

    static Product GetCustomerFood()
    {
        // Variable
        var availableFood = Menu.FoodAvailable;
        string userInput = "";

        // Prompt user for drink category
        for (int i = 0; i < availableFood.GroupsCollection.Count; i++) userInput += $"\n{i} : {availableFood.GroupsCollection[i].GroupName}";
        Console.WriteLine("What type of drink would you like to add?" + userInput);
        int chosenCategory = Convert.ToInt32(Console.ReadLine());
        userInput = ""; //Reset userInput

        // Prompt user for specific drink within that category
        for (int i = 0; i < availableFood.GroupsCollection[chosenCategory].FoodCollection.Count; i++) userInput += $"\n{i} : {availableFood.GroupsCollection[chosenCategory].FoodCollection[i].ItemName}";
        Console.WriteLine("What drinks would you like to add?" + userInput);
        int chosenFood = Convert.ToInt32(Console.ReadLine());

        var itemName = availableFood.GroupsCollection[chosenCategory].FoodCollection[chosenFood].ItemName;
        var price = availableFood.GroupsCollection[chosenCategory].FoodCollection[chosenFood].Price;
        var category = availableFood.GroupsCollection[chosenCategory].GroupName;
        return new Product(null, itemName, price, category);
    }
}
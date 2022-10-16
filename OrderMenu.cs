namespace Coffee_Shop_POS_Project;

public enum UserOptions
{
    Add = 1,
    Remove = 2,
    Replace = 3,
    Clear = 4,
    Proceed = 5,
    AddItemToMenu  = 6,
    RemoveItemFromMenu = 7,
    EndDay = 8
}

// Made into a regular class to take account of OrderMenu to make new OrderMenu for different Customers
internal sealed class OrderMenu
{
    // Field
    private static List<Product> ListOfProduct { get; set; } = new();
    // private UserOptions options; 
    
    // Behaviours
    // Option 1: Add a product to ListOfProduct
    internal void AddProduct()
    {
        Product productChoice;
        
        // Prompts for type of item
        Console.WriteLine("What are you adding?: \n1: Drink \n2: Food");
        int userChoice = Convert.ToInt32(Console.ReadLine());
        
        // Gets Food or Drinks depending ont userChoice
        if (userChoice == 1) productChoice = GetCustomerDrinks();
        else productChoice = GetCustomerFood();
        
        // Appending to order list
        ListOfProduct.Add(productChoice);
    }
    
    // Options 2: Remove a product from ListOfProduct
    internal void RemoveAProduct()
    {
        // TODO: Checks ListOfProducts is not empty
        
        // Displays items to remove
        string stringItems = "";
        for (int i = 0; i < ListOfProduct.Count; i++) stringItems += $"\n{i} : {ListOfProduct[i]}";
        Console.WriteLine("What item would you like to remove?" +
                          "\nItems currently in order are: " +
                          $"{stringItems}");
        
        // Prompt for item and removes it from List
        int indexToRemove = Convert.ToInt32(Console.ReadLine());
        ListOfProduct.Remove(ListOfProduct[indexToRemove]);
    }
    
    // Option 3: Replace a product from ListOfProduct with another product
    internal void ReplaceAProduct()
    {
        // Local Variables 
        Product itemToReplace;
        
        Console.WriteLine("This action removes an item and adds another one in it's place");
        // Displays items to remove
        string stringItems = "";
        for (int i = 0; i < ListOfProduct.Count; i++) stringItems += $"\n{i} : {ListOfProduct[i]}";
        Console.WriteLine("What item would you like to replace?" +
                          "\nItems currently in order are: " +
                          $"{stringItems}");

        int indexToReplace = Convert.ToInt32(Console.ReadLine());
        ListOfProduct.Remove(ListOfProduct[indexToReplace]);
        if (IsProductADrink(ListOfProduct[indexToReplace])) itemToReplace = GetCustomerDrinks();
        else itemToReplace = GetCustomerFood();
        ListOfProduct.Insert(indexToReplace,itemToReplace);
    }
    
    // Option 4: Clear the entire orderMenu
    internal void ClearOrderMenu() => ListOfProduct.Clear();
    
    // Option 5: Proceed with the order
    
    // Miscellaneous Methods
    // TODO: Decide later if these needs to be static
    internal static Product GetCustomerDrinks()
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
    internal static Product GetCustomerFood()
    {
        // Variable
        var availableFood = Menu.FoodAvailable;
        string userInput = "";

        // Prompt user for drink category
        for (int i = 0; i < availableFood.GroupsCollection.Count; i++) userInput += $"\n{i} : {availableFood.GroupsCollection[i].GroupName}";
        Console.WriteLine("What type of food would you like to add?" + userInput);
        int chosenCategory = Convert.ToInt32(Console.ReadLine());
        userInput = ""; //Reset userInput

        // Prompt user for specific drink within that category
        for (int i = 0; i < availableFood.GroupsCollection[chosenCategory].FoodCollection.Count; i++) userInput += $"\n{i} : {availableFood.GroupsCollection[chosenCategory].FoodCollection[i].ItemName}";
        Console.WriteLine("What food would you like to add?" + userInput);
        int chosenFood = Convert.ToInt32(Console.ReadLine());

        var itemName = availableFood.GroupsCollection[chosenCategory].FoodCollection[chosenFood].ItemName;
        var price = availableFood.GroupsCollection[chosenCategory].FoodCollection[chosenFood].Price;
        var category = availableFood.GroupsCollection[chosenCategory].GroupName;
        return new Product(DrinkSizes.Null, itemName, price, category);
    }
    internal static bool IsProductADrink(Product item)
    {
        bool returnState = true;
        foreach (var drinksCategory in Menu.DrinksAvailable.GroupsCollection)
            if (drinksCategory.GroupName == item.Category)
            {
                returnState = true;
            }
            else
            {
                returnState = false;
            }

        return returnState;
    }
}
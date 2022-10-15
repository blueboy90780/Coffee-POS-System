namespace Coffee_Shop_POS_Project;

internal struct CustomerOrder
{
    // Fields
    private Dictionary<string, Dictionary<string, (int, int, int)>> productChoice;
    
    // Property
    internal Dictionary<string, Dictionary<string, (int, int, int)>> ProductChoice
    {
        get => productChoice;
        set => productChoice = value;
    }

    // SetUpCustomerOrder with a list of empty products
    void AddCustomerOrder()
    {
        Console.WriteLine("\n Select the type of product to add: \n 1)Drinks \n 2)Desserts");
        int userChoice = Console.Read();

        // Checks for userChoice
        if (userChoice == 1) { ProductChoice = Menu.DrinksAvailable; }
        else if (userChoice == 2) { ProductChoice = Menu.DessertsAvailable; }
        
        // Tries to access productChoice
        Console.WriteLine(ProductChoice);
    }
}
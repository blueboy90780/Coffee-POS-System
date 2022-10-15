namespace Coffee_Shop_POS_Project;

internal struct CustomerOrder
{
    #region Fields
    private Dictionary<string, Dictionary<string, (int, int, int)>> _productChoice;
    private string _productType;
    #endregion

    #region Properties
    internal Dictionary<string, Dictionary<string, (int, int, int)>> ProductChoice
    {
        get => _productChoice;
        set => _productChoice = value;
    }
    internal string ProductType
    {
        get => _productType;
        set => _productType = value;
    }
    #endregion

    internal Dictionary<string, (int, int, int)> AddCustomerOrder()
    {
        // Variables
        int userChoice;
        string userChoiceString;
        string userChoiceString2;

        Console.WriteLine("Select the type of product to add: \n1)Drinks \n2)Desserts");
        userChoice = Convert.ToInt32(Console.ReadLine());

        // Checks for userChoice
        if (userChoice == 1)
        {
            ProductChoice = Menu.DrinksAvailable;
            ProductType = "drinks";
        }
        else if (userChoice == 2)
        {
            ProductChoice = Menu.DessertsAvailable;
            ProductType = "desserts";
        }

        Console.WriteLine($"Type out {ProductType} to add");
        foreach (var keyValue in ProductChoice) Console.WriteLine(keyValue.Key);
        userChoiceString = Console.ReadLine(); // Selects a sub-dict (e.g Traditional Coffee, Phin, Tea)

        Console.WriteLine($"Type out {ProductChoice[userChoiceString]} to add");
        foreach (var keyValue in ProductChoice[userChoiceString]) Console.WriteLine(keyValue.Key);
        userChoiceString2 = Console.ReadLine(); // Selects the last dict (e.g Iced Coffee with Condensed Milk)

        Console.WriteLine("Item has been successfully added, returning to menu order screen...");
        return new Dictionary<string, (int, int, int)> { userChoiceString2, ProductChoice[userChoiceString][userChoiceString2] };
    }
}
}
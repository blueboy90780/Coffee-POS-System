namespace Coffee_Shop_POS_Project;

public class Program
{
    // Main Method
    public static void Main()
    {
        // Console.WriteLine(Menu.DrinksAvailable);
        // Console.WriteLine(Menu.DessertsAvailable);

        CustomerOrder orderMenu = new CustomerOrder();
        var itemToAdd = orderMenu.PreCustomerOrder();
        
        // TODO: Find why itemToAdd.Key does not return anything
        string temp = itemToAdd.Key;
        var temp2 = itemToAdd.Value.Item1;
        
        Console.WriteLine($"{temp} and {temp2}");
    }
}
// See https://aka.ms/new-console-template for more information

using CoffeeShop_POS_Project_with_EF_Core.Domain;

namespace CoffeeShop_POS_Project_with_EF_Core;

internal class MainProgram
{
    public static void Main()
    {
        // Local Variables
        int userChoice = 0;
        int customerNumber = 1;

        Console.WriteLine(@"Welcome to David's Project #1: Coffee Shop POS System
This current state (beta) does not have any UI element nor does it have any AI elements. All inputs are to be manually given by the user (employee) for another customer");
        
        
        while (userChoice != (int) UserOptions.EndDay)
        {
            Console.WriteLine($"Customer #{customerNumber}");
            
            // Provides the options
            Console.WriteLine("Options: " +
                              "\n1: Add an item to Customer Order" +
                              "\n2: Delete an item from Customer Order" +
                              "\n3: Replace an item in Customer Order" +
                              "\n4: Proceed with the Order" +
                              "\n5: End day and generate a report for the day");
            userChoice = Convert.ToInt32(Console.ReadLine());
            
            switch (userChoice)
            {
                case (int) UserOptions.Add:
                    // Prompts for user what to choose
                    PromptForItem();
                    break;
                case (int) UserOptions.Delete:
                    // Do something
                case (int) UserOptions.Replace: // Delete and adding combined
                    // Do something
                case (int) UserOptions.Proceed:
                    // Do something
                case (int) UserOptions.EndDay:
                    break; // The statement "userChoice != (int) UserOptions.EndDay" gets evaluated to true false which will automatically break the loop
                default:
                    Console.WriteLine("That is an invalid input");
                    break;
                    
            }
            
            // Move to next Customer Number
            customerNumber += 1;
        }
        
        Console.WriteLine("Day Ended, generating report...");
        // Prints out report
    }

    private static void PromptForItem()
    {
        // Instance Variable
        int indexNumber = -1;
        
        // Connects to the database
        using var database = new DatabaseModel();

        // Gets available categories and prints them to console
        var availableCategory = database.Categories.Select(x => x.CategoryName);
        Console.WriteLine("The available categories are: \n");
        foreach (var categories in availableCategory)
        {
            indexNumber += 1;
            Console.WriteLine($"{indexNumber}: {categories}\n");
        }

        // Gets User Input
        Console.Write("Category Number: ");
        int categoryNumber = Convert.ToInt32(Console.ReadLine());
        
        // Gets the specific product
        // var availableProduct = database.ProductCatalogues.Where(x => x.ProductCatalogueId == 2);
        // var availableProduct2 = database.ProductCatalogues.Where(x => x.CategoriesId == 3);
    }
}

public enum UserOptions
{
    Add = 1,
    Delete = 2,
    Replace = 3,
    Proceed = 4,
    EndDay = 5
}
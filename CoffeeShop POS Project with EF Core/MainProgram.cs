// See https://aka.ms/new-console-template for more information

using CoffeeShop_POS_Project_with_EF_Core.Domain;

namespace CoffeeShop_POS_Project_with_EF_Core;

internal class MainProgram
{
    public static void Main()
    {
        // Local Variables
        var userChoice = 0;
        var customerNumber = 1;

        Console.WriteLine(@"Welcome to David's Project #1: Coffee Shop POS System
This current state (beta) does not have any UI element nor does it have any AI elements. All inputs are to be manually given by the user (employee) for another customer");


        while (userChoice != (int)UserOptions.EndDay)
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
                case (int)UserOptions.Add:
                    // Prompts for user what to choose
                    // var item = PromptForItem();
                    // Console.WriteLine(item.ENname);
                    break;
                case (int)UserOptions.Delete:
                // Do something
                case (int)UserOptions.Replace: // Delete and adding combined
                // Do something
                case (int)UserOptions.Proceed:
                // Do something
                case (int)UserOptions.EndDay:
                    break; // The statement "userChoice != (int) UserOptions.EndDay" gets evaluated to true false which will automatically break the loop
                default:
                    Console.WriteLine("That is an invalid input");
                    break;
            }

            // Move to next Customer Number
            customerNumber += 1;
        }
        Console.WriteLine("Day Ended, generating report...");
    }

    // private static Product PromptForItem()
    // {
    //     // Instance Variable
    //     var indexNumber = 0;
    //
    //     // Connects to the database
    //     using var database = new DatabaseModel();
    //
    //     // Gets a collection of categories from "Categories" table
    //     var availableCategory = database.Categories.Select(x => x.CategoryName);
    //     Console.WriteLine("The available categories are: \n");
    //
    //     // Displays available categories to choose from
    //     foreach (var categories in availableCategory)
    //     {
    //         indexNumber += 1;
    //         Console.WriteLine($"{indexNumber}: {categories}\n");
    //     }
    //
    //     // Gets user input and parses it to a category
    //     Console.Write("Category Number: ");
    //     var categoryNumber = Convert.ToInt32(Console.ReadLine());
    //     var chosenCategory =
    //         database.Categories.Find(categoryNumber); // Which contains the primary key for the reference key
    //
    //     // Gets a collection of products from "ProductProperties" table
    //     var availableProductRecords = database.ProductCatalogues.Where(x => x.Categories == chosenCategory);
    //     var availableProducts = availableProductRecords.Select(x => x.ENname).ToList();
    //
    //     // Displays available products to choose from the specified category
    //     for (var i = 0; i < availableProducts.Count; i++) Console.WriteLine($"{i}: {availableProducts[i]}");
    //
    //     // Prompt user for a product
    //     var productNumber = Convert.ToInt32(Console.ReadLine());
    //     var chosenProductString = availableProducts[productNumber];
    //
    //     // Gets the product the user has chosen
    //     var chosenProduct = availableProductRecords.Single(x => x.ENname == chosenProductString);
    //     return chosenProduct;
    // }
}

public enum UserOptions
{
    Add = 1,
    Delete = 2,
    Replace = 3,
    Proceed = 4,
    EndDay = 5
}
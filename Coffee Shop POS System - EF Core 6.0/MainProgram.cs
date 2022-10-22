// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Coffee_Shop_POS_System___EF_Core_6._0.Domain;

namespace Coffee_Shop_POS_System___EF_Core_6._0;

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
                              $"\n{(int) UserOptions.Add}: Add an item to Customer Order" +
                              $"\n{(int) UserOptions.Delete}: Delete an item from Customer Order" +
                              $"\n{(int) UserOptions.Replace}: Replace an item in Customer Order" +
                              $"\n{(int) UserOptions.Proceed}: Proceed with the Order" +
                              $"\n{(int) UserOptions.EndDay}: End day and generate a report for the day");
            Console.Write("Option: ");
            userChoice = Convert.ToInt32(Console.ReadLine());

            // Connects to the database
            using var database = new DatabaseModel();
            
            switch (userChoice)
            {
                case (int)UserOptions.Add:
                    // Prompts for user what to choose
                    var product = PromptForItem(database);
                    Console.WriteLine($"The product is: {product.Item2.ENname} ({product.Item1.ProductSize})");
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

    private static (ProductProperties, Product) PromptForItem(DatabaseModel database)
    {
        // Instance Variable
        var indexNumber = 0;

        // Gets a collection of categories from "Categories" table
        var availableCategory = database.Categories.Select(x => x.CategoryName);
        Console.WriteLine("\nThe available categories are: \n");
    
        // Displays available categories to choose from
        foreach (var categories in availableCategory)
        {
            indexNumber += 1;
            Console.WriteLine($"{indexNumber}: {categories}");
        }
        
        // Gets user input and parses it to a category
        Console.Write("\nCategory Number: ");
        var categoryNumber = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(); // New empty line

        // Gets a collection of products from "ProductProperties" table
        // var availableProductRecords = database.ProductCatalogues.Where(x => x.Categories == chosenCategory);
        var availableProductRecords = database.ProductCatalogues.Where(x => x.CategoriesId == categoryNumber);
        var availableProducts = availableProductRecords.Select(x => x.ENname).ToList();
    
        // Displays available products to choose from the specified category
        for (var i = 1; i < availableProducts.Count; i++) Console.WriteLine($"{i}: {availableProducts[i]}");
    
        // Prompt user for a product
        Console.Write("Product Choice: ");
        var productNumber = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        var chosenProductString = availableProducts[productNumber];
    
        // Gets the product the user has chosen
        Product chosenProduct = availableProductRecords.Single(x => x.ENname == chosenProductString);
        
        // Gets the record with the product's variation
        var productVariation = database.ProductVariants.Where(x => x.ProductId == chosenProduct.ProductId).ToList(); // 3 records stored
        
        // Local Variables
        uint productPrice = 0;
        Size? productSize = null;

        // Checks if the product has sizes
        if (productVariation.First().ProductSize != null)
        {
            // Ask for user input
            Console.WriteLine("The available sizes are: \n1: Small \n2: Medium \n3: Large");
            Console.Write("Size: ");
            Size chosenSize = (Size) Convert.ToInt32(Console.ReadLine());

            switch (chosenSize)
            {
                case Size.Small:
                    productPrice = productVariation.First().Price;
                    productSize = productVariation.First().ProductSize;
                    break;
                case Size.Medium:
                    productPrice = productVariation.ElementAt((int) Size.Medium).Price;
                    productSize = productVariation.ElementAt((int) Size.Medium).ProductSize;
                    break;
                case Size.Large:
                    productPrice = productVariation.ElementAt((int) Size.Large).Price;
                    productSize = productVariation.ElementAt((int) Size.Large).ProductSize;
                    break;
                default:
                    Console.WriteLine("Only numbers between 1-3 are valid");
                    break;
            }

        }
        ProductProperties productProperty = new ProductProperties { Price = productPrice, ProductSize = productSize };
        Product returnProduct = new Product { ENname = chosenProductString, Categories = database.Categories.Single(x => x.CategoriesId == categoryNumber) };

        return (productProperty, returnProduct);
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
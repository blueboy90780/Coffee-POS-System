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

        #region Start Print Output
        Console.WriteLine(@"Welcome to David's Project #1: Coffee Shop POS System
This current state (beta) does not have any UI element nor does it have any AI elements. All inputs are to be manually given by the user (employee) for another customer");

        Console.WriteLine("Options: " +
                          $"\n{(int) UserOptions.Add}: Add an item to Customer Order" +
                          $"\n{(int) UserOptions.Delete}: Delete an item from Customer Order" +
                          $"\n{(int) UserOptions.Replace}: Replace an item in Customer Order" +
                          $"\n{(int) UserOptions.Proceed}: Proceed with the Order" +
                          $"\n{(int) UserOptions.EndDay}: End day and generate a report for the day");
        #endregion

        while (userChoice != (int)UserOptions.EndDay)
        {
            // Display Customer Number
            Console.WriteLine($"\nCustomer #{customerNumber}");
            
            // Connects to the database
            using var database = new DatabaseModel();
            
            // Displays all the items in the current order menu
            var itemName = database.CustomerOrders.Select(x => x.Product.ENname);
            var itemPrice = database.CustomerOrders.Select(x => x.ProductProperties.Price);

            for (int orderNumber = 1; orderNumber < database.CustomerOrders.Count(); orderNumber++)
            {
                Console.WriteLine($"{orderNumber}: {itemName.ElementAt(orderNumber)} \t {itemPrice.ElementAt(orderNumber)}");
            }
            
            // Get Options
            Console.Write("Option: ");
            userChoice = Convert.ToInt32(Console.ReadLine());
            
            switch (userChoice)
            {
                // Adds an Item to Order Menu
                case (int)UserOptions.Add:
                    
                    // Prompts for user input
                    var productSet = PromptForItem(database);
                    database.CustomerOrders.Add(new CustomerOrder()
                        { Product = productSet.Item2, ProductProperties = productSet.Item1, ProductId = productSet.Item2.ProductId, ProductPropertiesId = productSet.Item1.ProductPropertiesId});
                    database.SaveChanges();
                    Console.WriteLine($"\nAdded product {productSet.Item2.ENname} ({productSet.Item1.ProductSize}) to order menu");
                    break;
                
                // Deletes an Item to Order Menu
                case (int)UserOptions.Delete:
                    
                    // Prompt user for item
                    Console.WriteLine("Which product to remove?");
                    Console.Write("Item Number: ");
                    int deleteNumber = Convert.ToInt32(Console.ReadLine());
                    
                    database.CustomerOrders.Remove(database.CustomerOrders.Find(deleteNumber) ?? throw new InvalidOperationException());

                    database.SaveChanges();
                    
                    Console.WriteLine($"Item Number {deleteNumber} has been deleted");
                    break;
                
                // Replaces (delete and add at specific index) to Order Menu
                case (int)UserOptions.Replace:
                    // Prompt user for item
                    Console.WriteLine("Which product to replace?");
                    Console.Write("Item Number: ");
                    uint replaceNumber = Convert.ToUInt32(Console.ReadLine());
                    
                    database.CustomerOrders.Remove(database.CustomerOrders.Find(replaceNumber) ?? throw new InvalidOperationException());
                    
                    // TODO: Finish this option
                    break;
                
                // Proceed with the customer Order
                case (int)UserOptions.Proceed:
                    break; // Breaks the switch statement to increment customerNumber
                
                // Ends the day
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
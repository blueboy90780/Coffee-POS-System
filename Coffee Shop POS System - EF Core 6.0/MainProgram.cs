﻿using Coffee_Shop_POS_System___EF_Core_6._0.Domain;

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
                          $"\n{(int)UserOptions.Add}: Add an item to Customer Order" +
                          $"\n{(int)UserOptions.Delete}: Delete an item from Customer Order" +
                          $"\n{(int)UserOptions.Replace}: Replace an item in Customer Order" +
                          $"\n{(int)UserOptions.Proceed}: Proceed with the Order" +
                          $"\n{(int)UserOptions.EndDay}: End day and generate a report for the day");

        #endregion

        while (userChoice != (int)UserOptions.EndDay)
        {
            // Display Customer Number
            Console.WriteLine($"\nCustomer #{customerNumber}");

            // Connects to the database
            var database = new DatabaseModel();

            var tableCounter = database.CustomerOrders.Count();
            Console.WriteLine($"Current Items in Order: {tableCounter}");

            if (tableCounter >= 1)
            {
                // Displays all the items in the current order menu
                var itemName = database.CustomerOrders.Select(x => x.ProductCatalogue.ENname);
                var itemPrice = database.CustomerOrders.Select(x => x.ProductProperties.Price);

                for (var orderNumber = 1; orderNumber < database.ProductCatalogues.Count(); orderNumber++)
                    Console.WriteLine(
                        $"{orderNumber}: {itemName.ElementAt(orderNumber)} \t {itemPrice.ElementAt(orderNumber)}");
            }

            // Get Options
            Console.Write("Option: ");
            userChoice = Convert.ToInt32(Console.ReadLine());

            switch (userChoice)
            {
                #region Add to Order Menu

                // Adds an Item to Order Menu
                case (int)UserOptions.Add:

                    // Prompts for user input
                    var productSet = PromptForItem(database);

                    // Parses productSet into a proper CustomerOrder object
                    var entityOrderToAdd = new CustomerOrder()
                        {
                            ProductCatalogue = productSet.Item2,
                            ProductProperties = productSet.Item1, 
                        };

                    using (database = new DatabaseModel())
                    {
                        database.CustomerOrders.Add(entityOrderToAdd);
                        database.SaveChanges();
                    }

                    Console.WriteLine($"\nAdded product {productSet.Item2.ENname} ({productSet.Item1.Price}) to order menu");
                    
                    break;

                #endregion

                #region Delete from Order Menu

                // Deletes an Item to Order Menu
                case (int)UserOptions.Delete:

                    // Prompt user for item
                    Console.WriteLine("Which product to remove?");
                    Console.Write("Item Number: ");
                    var deleteNumber = Convert.ToInt32(Console.ReadLine());

                    database.CustomerOrders.Remove(database.CustomerOrders.Find(deleteNumber) ??
                                                   throw new InvalidOperationException());

                    // database.SaveChanges();

                    Console.WriteLine($"Item Number {deleteNumber} has been deleted");
                    break;

                #endregion

                #region Replaces an item from Order Menu

                // Replaces (delete and add at specific index) to Order Menu
                case (int)UserOptions.Replace:
                    // Prompt user for item
                    Console.WriteLine("Which product to replace?");
                    Console.Write("Item Number: ");
                    var replaceId = Convert.ToUInt32(Console.ReadLine());

                    // Gets the record the user wants to change
                    var recordToChange = database.CustomerOrders.Find(replaceId);

                    // Prompts user the product to replace with
                    Console.WriteLine("What product would you like to replace the current product with?");
                    var newProduct = PromptForItem(database);

                    // Updates the Order Menu properties
                    recordToChange!.ProductCatalogue = newProduct.Item2;
                    recordToChange!.ProductProperties = newProduct.Item1;

                    // database.SaveChanges();

                    Console.WriteLine("Change applied");

                    break;

                #endregion

                #region Proceed with Customer Order

                // Proceed with the customer Order
                case (int)UserOptions.Proceed:
                    break; // Breaks the switch statement to increment customerNumber

                #endregion

                #region Ends the Day

                // Ends the day
                case (int)UserOptions.EndDay:
                    break; // The statement "userChoice != (int) UserOptions.EndDay" gets evaluated to true false which will automatically break the loop

                #endregion

                default:
                    Console.WriteLine("That is an invalid input");
                    break;
            }

            // Move to next Customer Number
            customerNumber += 1;
        }

        Console.WriteLine("Day Ended, generating report...");
    }

    private static (ProductProperties, ProductCatalogue) PromptForItem(DatabaseModel database)
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
        var chosenProductCatalogue = availableProductRecords.Single(x => x.ENname == chosenProductString);

        // Gets the record with the product's variation
        var productVariation = database.ProductProperties
            .Where(x => x.ProductCatalogueId == chosenProductCatalogue.ProductCatalogueId).ToList(); // 3 records stored

        // Local Variables
        uint productPrice = 0;
        Size? productSize = null;
        ProductProperties productProperty;

        // Checks if the product has sizes
        if (productVariation.First().ProductSize != null)
        {
            // Ask for user input
            Console.WriteLine("The available sizes are: \n1: Small \n2: Medium \n3: Large");
            Console.Write("Size: ");
            var chosenSize = (Size)Convert.ToInt32(Console.ReadLine());

            switch (chosenSize)
            {
                case Size.Small:
                    productPrice = productVariation.First().Price;
                    productSize = productVariation.First().ProductSize;
                    break;
                case Size.Medium:
                    productPrice = productVariation.ElementAt((int)Size.Medium).Price;
                    productSize = productVariation.ElementAt((int)Size.Medium).ProductSize;
                    break;
                case Size.Large:
                    productPrice = productVariation.ElementAt((int)Size.Large).Price;
                    productSize = productVariation.ElementAt((int)Size.Large).ProductSize;
                    break;
                default:
                    Console.WriteLine("Only numbers between 1-3 are valid");
                    break;
            }

            productProperty = productVariation[(int) chosenSize];
        }
        else
        {
            productProperty = productVariation[0];
        }
        
        var returnProduct = database.ProductCatalogues.Single(x => x.ENname == chosenProductString);
        // Instantiates variables to return
        // var productProperty = new ProductProperties
        // {
        //     Price = productPrice,
        //     ProductSize = productSize
        // };

        // var returnProduct = new ProductCatalogue
        // {
        //     ENname = chosenProductString,
        //     CategoriesId = categoryNumber,
        //     Recommended = 
        //     // Categories = database.Categories.Single(x => x.CategoriesId == categoryNumber)
        // };


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
using Coffee_Shop_POS_System___Dapper.Domain;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Coffee_Shop_POS_System___Dapper;

internal class MainProgram
{
    public static void Main()
    {
        // Local Variables
        var userChoice = 0;
        var customerNumber = 1;

        #region Output Landing Screen

        Console.WriteLine(@"Welcome to David's Project #1: Coffee Shop POS System
This current state (beta) does not have any UI element nor does it have any AI elements. All inputs are to be manually given by the user (employee) for another customer");

        Console.WriteLine("Options: " +
                          $"\n{(int)UserOptions.Add}: Add an item to Customer Order" +
                          $"\n{(int)UserOptions.Delete}: Delete an item from Customer Order" +
                          $"\n{(int)UserOptions.Replace}: Replace an item in Customer Order" +
                          $"\n{(int)UserOptions.Proceed}: Proceed with the Order" +
                          $"\n{(int)UserOptions.EndDay}: End day and generate a report for the day");

        #endregion

        // #region Main Code
        while (userChoice != (int)UserOptions.EndDay)
        {
            // Display Customer Number
            Console.WriteLine($"\nCustomer #{customerNumber}");

            // Connect to database
            using var database =
                new SqliteConnection("Data Source=/home/davidnguyen/Documents/Coffee-POS-System/CoffeeShopDB.db;");

            // Displays all the items in the current order menu
            var itemName = database.Query<CustomerOrder>("INSERT INTO `Customer Order Menu` VALUES (1, 1, 3, 4);");

            Console.WriteLine("Program Ends");

            // var itemName = database.CustomerOrders.Select(x => x.Product.ENname);
            // var itemPrice = database.CustomerOrders.Select(x => x.ProductProperties.Price);
            //     
            //     for (int orderNumber = 1; orderNumber < database.CustomerOrders.Count(); orderNumber++)
            //     {
            //         Console.WriteLine($"{orderNumber}: {itemName.ElementAt(orderNumber)} \t {itemPrice.ElementAt(orderNumber)}");
            //     }
            //     
            //     // Get Options
            //     Console.Write("Option: ");
            //     userChoice = Convert.ToInt32(Console.ReadLine());
            //     
            //     switch (userChoice)
            //     {
            //         #region Add to Order Menu
            //         // Adds an Item to Order Menu
            //         case (int)UserOptions.Add:
            //             
            //             // Prompts for user input
            //             var productSet = PromptForItem(database);
            //
            //             // Parses productSet into a proper CustomerOrder object
            //             CustomerOrder entityOrderToAdd = new CustomerOrder { Product = productSet.Item2, ProductProperties = productSet.Item1 };
            //
            //             // Checks if the entity exists within the model
            //             if (database.CustomerOrders.Contains(entityOrderToAdd))
            //             {
            //                 // If already exists, increment quantity
            //                 entityOrderToAdd.Quantity++;
            //             } else
            //             {
            //                 // Adds a new entity to DBSet
            //                 database.Add(entityOrderToAdd);
            //             };
            //
            //             // Saves changes
            //             database.SaveChanges();
            //             
            //             // Write out confirmation message
            //             Console.WriteLine($"\nAdded product {productSet.Item2.ENname} ({productSet.Item1.Price}) to order menu");
            //             break;
            //         #endregion
            //
            //         #region Delete from Order Menu
            //         // Deletes an Item to Order Menu
            //         case (int)UserOptions.Delete:
            //             
            //             // Prompt user for item
            //             Console.WriteLine("Which product to remove?");
            //             Console.Write("Item Number: ");
            //             int deleteNumber = Convert.ToInt32(Console.ReadLine());
            //             
            //             database.CustomerOrders.Remove(database.CustomerOrders.Find(deleteNumber) ?? throw new InvalidOperationException());
            //
            //             database.SaveChanges();
            //             
            //             Console.WriteLine($"Item Number {deleteNumber} has been deleted");
            //             break;
            //         #endregion
            //
            //         #region Replaces an item from Order Menu
            //         // Replaces (delete and add at specific index) to Order Menu
            //         case (int)UserOptions.Replace:
            //             // Prompt user for item
            //             Console.WriteLine("Which product to replace?");
            //             Console.Write("Item Number: ");
            //             uint replaceId = Convert.ToUInt32(Console.ReadLine());
            //             
            //             // Gets the record the user wants to change
            //             var recordToChange = database.CustomerOrders.Find(replaceId);
            //             
            //             // Prompts user the product to replace with
            //             Console.WriteLine("What product would you like to replace the current product with?");
            //             var newProduct = PromptForItem(database);
            //             
            //             // Updates the Order Menu properties
            //             recordToChange!.Product = newProduct.Item2;
            //             recordToChange!.ProductProperties = newProduct.Item1;
            //
            //             database.SaveChanges();
            //             
            //             Console.WriteLine("Change applied");
            //             
            //             break;
            //         #endregion
            //
            //         #region Proceed with Customer Order
            //         // Proceed with the customer Order
            //         case (int)UserOptions.Proceed:
            //             break; // Breaks the switch statement to increment customerNumber
            //         #endregion
            //
            //         #region Ends the Day
            //         // Ends the day
            //         case (int)UserOptions.EndDay:
            //             break; // The statement "userChoice != (int) UserOptions.EndDay" gets evaluated to true false which will automatically break the loop
            //         #endregion
            //         default:
            //             Console.WriteLine("That is an invalid input");
            //             break;
            //     }
            //
            //     // Move to next Customer Number
            //     customerNumber += 1;
            // }
            // #endregion
            // Console.WriteLine("Day Ended, generating report...");
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
}

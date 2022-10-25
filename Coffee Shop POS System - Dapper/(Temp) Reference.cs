using Coffee_Shop_POS_System___Dapper.Domain;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Coffee_Shop_POS_System___Dapper;

public class _Temp__Reference
{
    void RandomMethod()
    {
        // Connection String
        var getAllQuery = @"SElECT * FROM 'Product Catalogue'";
    
        using (var connection = new SqliteConnection("Data Source=/home/davidnguyen/Documents/Coffee-POS-System/CoffeeShopDB.db;"))
        {
            var productRecords = connection.Query<ProductCatalogue>(getAllQuery).ToList();
            
            for (int i = 0; i < productRecords.Count; i++)
            {
                Console.WriteLine(productRecords[i].ENname);
            }
        }
    }
}
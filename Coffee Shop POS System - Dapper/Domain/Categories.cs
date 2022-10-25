using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_Shop_POS_System___Dapper.Domain;

[Table("Categories")]
public class Categories
{
    // Entity Properties
    public int CategoriesId { get; set; }
    public string CategoryName { get; set; }
    public bool IceAvailable { get; set; }
    
    // One (Category) records to many (Products) records
    // Multiple category FK in the product entity
    public List<ProductCatalogue> Products { get; set; }
}
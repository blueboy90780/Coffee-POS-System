using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_Shop_POS_System___EF_Core_6._0.Domain;

[Table("Categories")]
public class Categories
{
    // Entity Properties
    public int CategoriesId { get; set; }
    public string CategoryName { get; set; }
    public bool IceAvailable { get; set; }
    
    // One (Category) records to many (Products) records
    // Multiple category FK in the product entity
    public List<Product> Products { get; set; }
}
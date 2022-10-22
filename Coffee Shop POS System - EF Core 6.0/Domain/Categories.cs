using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_Shop_POS_System___EF_Core_6._0.Domain;

[Table("Categories")]
public class Categories
{
    public int CategoriesId { get; set; }
    public string CategoryName { get; set; }
    public bool IceAvailable { get; set; }
    public List<Product> Products { get; set; }
}
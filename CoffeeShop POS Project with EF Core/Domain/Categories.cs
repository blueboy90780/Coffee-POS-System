using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop_POS_Project_with_EF_Core.Domain;

[Table("Categories")]
public class Categories
{
    public Categories()
    {
        CategoryName = "";
        Products = new List<Product>();
    }

    public int CategoriesId { get; set; }
    public string CategoryName { get; set; }
    public bool IceAvailable { get; set; }
    public List<Product> Products { get; set; }
}
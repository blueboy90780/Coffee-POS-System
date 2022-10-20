using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop_POS_Project_with_EF_Core.Domain;

[Table("Categories")]
internal class Categories
{
    [MaxLength(100)] public int CategoriesId { get; set; }
    
    // Limiting to a select few choice of pre-defined categories
    public string CategoryName { get; set; }
    public bool? IceAvailable { get; set; }
    public List<ProductCatalogue> Products { get; set; }
}
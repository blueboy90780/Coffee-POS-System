using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop_POS_Project_with_EF_Core.Domain;

[Table("Categories")]
internal class Category
{
    [MaxLength(100)] public int CategoryId { get; set; }

    public string CategoryName { get; set; }
    public bool? IceAvailable { get; set; }
    public List<Product> Products { get; set; } = new();
}
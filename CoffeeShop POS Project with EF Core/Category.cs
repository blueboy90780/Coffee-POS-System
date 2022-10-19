using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop_POS_Project_with_EF_Core;

[Table("Categories")]
internal class Category
{
    [MaxLength(100)]
    public string CategoryName { get; set; }
    public int CategoryId { get; set; }
    public int SizeAvailable { get; set; }
    public bool? IceAvailable { get; set; }
    public bool VolumeAvailable { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();
}

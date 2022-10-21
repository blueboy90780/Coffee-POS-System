using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop_POS_Project_with_EF_Core.Domain;

[Table("Product Properties")]
public class ProductProperties
{
    public int ProductPropertiesId { get; set; }

    // public List<CustomerOrder> ProductNumber { get; set; }

    // Each product will have it's own individual price and corresponding size and volume. Thereby accounting for products the dynamic size and volume of Each product 
    [Required] public uint Price { get; set; }
    public Size? ProductSize { get; set; }
    public float? Volume { get; set; }

    public Product Product { get; set; }
    public int ProductId { get; set; }
}

public enum Size
{
    Small,
    Medium,
    Large
}
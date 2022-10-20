using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop_POS_Project_with_EF_Core.Domain;

[Table("ProductVariants")]
public class ProductVariants
{
    public int ProductVariantsId { get; set; }
    public ProductCatalogue ProductCatalogue { get; set; }
    public List<CustomerOrder> ProductNumber { get; set; } // Creates a foreign key on CustomerOrder() I think
    
    // Each product will have it's own individual price and corresponding size and volume. Thereby accounting for products the dynamic size and volume of Each product 
    [Required] public uint Price { get; set; }
    public Size? ProductSize { get; set; }
    public float? Volume { get; set; }
}

public enum Size
{
    Small,
    Medium,
    Large
}
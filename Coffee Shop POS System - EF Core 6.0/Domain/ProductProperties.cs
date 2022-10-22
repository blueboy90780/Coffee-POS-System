using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_Shop_POS_System___EF_Core_6._0.Domain;

[Table("Product Properties")]
public class ProductProperties
{
    public int ProductPropertiesId { get; set; }

    // public List<CustomerOrder> ProductNumber { get; set; }

    // Each product will have it's own individual price and corresponding size and volume. Thereby accounting for products the dynamic size and volume of Each product 
    [Required] public uint Price { get; set; }
    public Size? ProductSize { get; set; }
    public float? Volume { get; set; }
    
    // Foreign Key Relationship
    public Product Product { get; set; }
    public int ProductId { get; set; }
}

public enum Size
{
    Small = 1,
    Medium = 2,
    Large = 3
}
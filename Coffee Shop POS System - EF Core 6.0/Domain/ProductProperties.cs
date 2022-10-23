using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_Shop_POS_System___EF_Core_6._0.Domain;

[Table("Product Properties")]
public class ProductProperties
{
    // Entity Properties
    public int ProductPropertiesId { get; set; }
    [Required] public uint Price { get; set; }
    public Size? ProductSize { get; set; }
    public float? Volume { get; set; }
    
    // Foreign Key Relationship - Parent: Product
    public Product Product { get; set; } // Navigation Property
    public int ProductId { get; set; } // Parent Key

    // Foreign Key Relationship - Parent: CustomerOrder
    public CustomerOrder CustomerOrder { get; set; }
    public int? CustomerOrderId { get; set; }
}

public enum Size
{
    Small = 1,
    Medium = 2,
    Large = 3
}
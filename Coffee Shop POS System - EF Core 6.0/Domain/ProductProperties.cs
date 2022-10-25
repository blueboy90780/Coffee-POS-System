using System.ComponentModel.DataAnnotations;

namespace Coffee_Shop_POS_System___EF_Core_6._0.Domain;

public class ProductProperties
{
    // Entity Properties
    public int ProductPropertiesId { get; set; }
    [Required] public uint Price { get; set; }
    public Size? ProductSize { get; set; }
    public float? Volume { get; set; }

    // One (ProductProperties) PK to Many (CustomerOrder) FK
    public List<CustomerOrder> CustomerOrders { get; set; }

    // Foreign Key Relationship - Parent: Product
    public ProductCatalogue ProductCatalogue { get; set; } // Navigation Property
    public int ProductCatalogueId { get; set; } // Parent Key
}

public enum Size
{
    Small = 1,
    Medium = 2,
    Large = 3
}
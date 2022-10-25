using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_Shop_POS_System___EF_Core_6._0.Domain;

public class CustomerOrder
{
    // Entity Properties
    public int CustomerOrderId { get; set; }
    public int Quantity { get; set; }

    // Foreign Key Relationship - Parent: Products
    public ProductCatalogue ProductCatalogue { get; set; }
    public int ProductCatalogueId { get; set; }
    
    // Foreign Key Relationship - Parent: ProductProperties
    public ProductProperties ProductProperties { get; set; }
    public int ProductPropertiesId { get; set; }

    // Class Data
    [NotMapped] public uint TotalCost { get; set; } // Property to hold the total cost of ItemOrder
}
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_Shop_POS_System___EF_Core_6._0.Domain;

[Table("Customer Order Menu")]
public class CustomerOrder
{
    // DBContext Properties
    public int CustomerOrderId { get; set; }
    public uint Quantity { get; set; }
    
    // Foreign Key Relationship
    public Product Product { get; set; } // For product name as well as 
    public ProductProperties ProductProperties { get; set; } // For pricing and ice information
    public int ProductId { get; set; }
    public int ProductPropertiesId { get; set; }

    // Other Properties
    [NotMapped] public uint TotalCost { get; set; } // Property to hold the total cost of ItemOrdered
}
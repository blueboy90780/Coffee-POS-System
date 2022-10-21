using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop_POS_Project_with_EF_Core.Domain;

[Table("Customer Order Menu")]
public class CustomerOrder
{
    public int CustomerOrderId { get; set; }
    public Product Product { get; set; } // For product name as well as 
    public ProductProperties ProductProperties { get; set; } // For pricing and ice information
    public uint Quantity { get; set; }

    [NotMapped] public uint TotalCost { get; set; } // Property to hold the total cost of ItemOrdered
}
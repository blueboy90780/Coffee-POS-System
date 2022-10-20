using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop_POS_Project_with_EF_Core.Domain;

[Table("CustomerOrder")]
public class CustomerOrder
{
    public List<ProductVariants> ItemOrdered { get; set; } // List of product that customers ordered
    public uint Quantity { get; set; }
    
    [NotMapped]
    public uint TotalCost { get; set; } // Property to hold the total cost of ItemOrdered
}
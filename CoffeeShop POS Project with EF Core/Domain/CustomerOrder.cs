using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop_POS_Project_with_EF_Core.Domain;

[Table("CustomerOrder")]
public class CustomerOrder
{
    public int CustomerOrderId { get; set; }
    public uint Quantity { get; set; }

    [NotMapped]
    public uint TotalCost { get; set; } // Property to hold the total cost of ItemOrdered
}
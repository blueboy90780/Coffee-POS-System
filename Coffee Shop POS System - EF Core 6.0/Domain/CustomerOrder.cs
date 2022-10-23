using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_Shop_POS_System___EF_Core_6._0.Domain;

[Table("Customer Order Menu")]
public class CustomerOrder
{
    // Entity Properties
    public int CustomerOrderId { get; set; }
    public int Quantity { get; set; }

    // One (Customer Order Key) to Many (Prodcut Records)
    public List<Product> Product { get; set; }
    public List<ProductProperties> ProductProperties { get; set; }

    // Class Data
    [NotMapped] public uint TotalCost { get; set; } // Property to hold the total cost of ItemOrdered
    
    // Class Behaviour
    public uint CountProduct()
    {
        throw new NotImplementedException();
    }

    public void IncrementQuantity()
    {
        Quantity++;
    }
}
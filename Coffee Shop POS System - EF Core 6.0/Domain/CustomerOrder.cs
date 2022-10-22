using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_Shop_POS_System___EF_Core_6._0.Domain;

[Table("Customer Order Menu")]
public class CustomerOrder
{
    public CustomerOrder(Product product, ProductProperties productProperties)
    {
        Product = product;
        ProductProperties = productProperties;
        // ProductId = Product.ProductId;
        // ProductPropertiesId = ProductProperties.ProductPropertiesId;
    }
    
    public CustomerOrder()
    {
        // Does nothing
    }

    // DBContext Properties
    public int CustomerOrderId { get; set; }
    
    // Fields of CustomerOrder()
    public Product Product { get; set; }
    public ProductProperties ProductProperties { get; set; }
    // public int ProductId { get; set; }
    // public int ProductPropertiesId { get; set; }

    // Other Properties
    [NotMapped] public uint TotalCost { get; set; } // Property to hold the total cost of ItemOrdered
    
    // Counts how many of each product there is
    public uint CountProduct()
    {
        throw new NotImplementedException();
    }
}
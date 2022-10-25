using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_Shop_POS_System___Dapper.Domain;

[Table("Product Catalogue")]
public class ProductCatalogue
{
    //Product ID
    public int ProductId { get; set; }

    // Name of the product
    public string ENname { get; set; }
    public string? VNname { get; set; }
    public bool Recommended { get; set; } // Recommended or not

    // One (Product) records / key to many (ProductProperties) records
    public List<ProductProperties> ProductVariantsList { get; set; } // Each product has 3 of it's own variations
    
    // Foreign Key Relationship - Parent: Categories
    public Categories Categories { get; set; } //<-- navigation property
    public int CategoriesId { get; set; }

    // Foreign Key Relationship - Parent: Customer Order
    public CustomerOrder CustomerOrder { get; set; }
    public int? CustomerOrderId { get; set; }
}
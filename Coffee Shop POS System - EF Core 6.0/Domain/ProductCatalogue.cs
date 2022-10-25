using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Coffee_Shop_POS_System___EF_Core_6._0.Domain;

public class ProductCatalogue
{
    public ProductCatalogue()
    {
        ProductProperties = new List<ProductProperties>();
    }

    // Product Properties
    public int ProductCatalogueId { get; set; }
    [MaxLength(100)] [Unicode(false)] public string ENname { get; set; }
    [MaxLength(100)] public string? VNname { get; set; }
    public bool Recommended { get; set; } // Recommended or not

    // One (Product) records / key to many (ProductProperties) records
    public List<ProductProperties> ProductProperties { get; set; }

    // One (Product) records / key to many (ProductProperties) records
    public List<CustomerOrder> CustomerOrders { get; set; }

    // Foreign Key Relationship - Parent: Categories
    public Categories Categories { get; set; } //<-- navigation property
    public int CategoriesId { get; set; }
}
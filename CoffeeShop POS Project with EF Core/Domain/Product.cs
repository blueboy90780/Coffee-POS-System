using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop_POS_Project_with_EF_Core.Domain;

[Table("Product Catalogue")]
public class Product
{
    public Product()
    {
        ProductVariantsList = new List<ProductProperties>();
    }

    //Product ID
    public int ProductId { get; set; }

    // Name of the product
    [MaxLength(100)] [Unicode(false)] public string ENname { get; set; }
    [MaxLength(100)] public string? VNname { get; set; }
    public List<ProductProperties> ProductVariantsList { get; set; } // Each product has 3 of it's own variations
    public bool Recommended { get; set; } // Recommended or not
    
    // Foreign Key Relationship
    public Categories Categories { get; set; } //<-- navigation property
    public int CategoriesId { get; set; }
}
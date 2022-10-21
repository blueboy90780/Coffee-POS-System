using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop_POS_Project_with_EF_Core.Domain;

[Table("Product Catalogue")]
public class Product
{
    public int ProductId { get; set; }
    
    // Name of the product
    [MaxLength(100)] [Unicode(false)] public string ENname { get; set; }
    [MaxLength(100)] public string? VNname { get; set; }
    
    // Miscellaneous Information
    public Categories Category; // Each product belongs to a category
    public List<ProductProperties> ProductVariantsList { get; set; } // Each product has 3 of it's own variations
    public bool Recommended { get; set; } // Recommended or not
}
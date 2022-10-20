using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop_POS_Project_with_EF_Core.Domain;

[Table("Products")]
internal class Product
{
    public int ProductId { get; set; }

    [MaxLength(100)] public string VNname { get; set; }

    [MaxLength(100)] [Unicode(false)] public string ENname { get; set; }

    public bool Recommended { get; set; }
    public Size? ProductSize { get; set; }
    public List<ProductVariants> ProductVariantsList { get; set; }
}

[Table("ProductVariants")]
internal class ProductVariants
{
    public int Id { get; set; }
    public Product Product { get; set; }
    
    // Each product will have it's own individual price and corresponding size and volume. Thereby accounting for products the dynamic size and volume of Each product 
    [Required] public int Price { get; set; }
    public Size? Size{ get; set; }
    public float? Volume { get; set; }
}

public enum Size
{
    Small,
    Medium,
    Large
}
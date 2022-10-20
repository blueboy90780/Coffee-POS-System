using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop_POS_Project_with_EF_Core.Domain;

[Table("ProductCatalogue")]
public class ProductCatalogue
{
    public int ProductId { get; set; }

    [MaxLength(100)] [Unicode(false)] public string ENname { get; set; }

    [MaxLength(100)] public string? VNname { get; set; }

    public bool Recommended { get; set; }
    public List<ProductVariants> ProductVariantsList { get; set; } // TODO: Look into this at DataGrip
}

[Table("ProductVariants")]
public class ProductVariants
{
    public int ProductVariantsId { get; set; }
    public ProductCatalogue ProductCatalogue { get; set; }
    
    // Each product will have it's own individual price and corresponding size and volume. Thereby accounting for products the dynamic size and volume of Each product 
    [Required] public uint Price { get; set; }
    public Size? ProductSize { get; set; }
    public float? Volume { get; set; }
}

public enum Size
{
    Small,
    Medium,
    Large
}
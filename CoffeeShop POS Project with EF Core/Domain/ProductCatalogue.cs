using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop_POS_Project_with_EF_Core.Domain;

[Table("ProductCatalogue")]
public class ProductCatalogue
{
    public int ProductCatalogueId { get; set; }

    [MaxLength(100)] [Unicode(false)] public string ENname { get; set; }

    [MaxLength(100)] public string? VNname { get; set; }

    public bool Recommended { get; set; }
    public List<ProductVariants> ProductVariantsList { get; set; } // Responsible for creading the foreign key
}
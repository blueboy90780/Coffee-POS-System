using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop_POS_Project_with_EF_Core;

[Table("Products")]
internal class Product
{
    public int ProductId { get; set; }

    [MaxLength(100)] public string VNname { get; set; }

    [MaxLength(100)] [Unicode(false)] public string ENname { get; set; }

    [Required] public int Price { get; set; }

    public bool Recommended { get; set; }
    public Size? ProductSize { get; set; }
    public float? Volume { get; set; }
}

public enum Size
{
    Small,
    Medium,
    Large
}
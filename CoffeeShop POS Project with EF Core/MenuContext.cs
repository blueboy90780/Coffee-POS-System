using CoffeeShop_POS_Project_with_EF_Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop_POS_Project_with_EF_Core;

internal class MenuContext : DbContext
{
    public DbSet<ProductCatalogue> Products { get; set; }
    public DbSet<Categories> Categories { get; set; }
    public DbSet<ProductVariants> ProductVariants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // var workingDirectory = Environment.CurrentDirectory;
        // var projectDirectory = Directory.GetParent(workingDirectory)!.Parent!.Parent!.FullName!;
        optionsBuilder.UseSqlite(@"Data Source=D:\CoffeeShopDB.db");
    }
}
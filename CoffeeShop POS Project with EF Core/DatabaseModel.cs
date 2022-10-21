using CoffeeShop_POS_Project_with_EF_Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop_POS_Project_with_EF_Core;

internal class DatabaseModel : DbContext
{
    public DbSet<Product> ProductCatalogues { get; set; }
    public DbSet<Categories> Categories { get; set; }
    public DbSet<ProductProperties> ProductVariants { get; set; }
    public DbSet<CustomerOrder> CustomerOrders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // var workingDirectory = Environment.CurrentDirectory;
        // var projectDirectory = Directory.GetParent(workingDirectory)!.Parent!.Parent!.FullName!;
        optionsBuilder.UseSqlite(@"Data Source=D:\CoffeeShopDB.db")
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
}
using Coffee_Shop_POS_System___EF_Core_6._0.Domain;
using Microsoft.EntityFrameworkCore;

namespace Coffee_Shop_POS_System___EF_Core_6._0;

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
        optionsBuilder.UseSqlite(@"Data Source=/run/media/davidnguyen/Share Drive/Coding Repositories/Coffee Shop POS System/CoffeeShopDB.db")
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
}
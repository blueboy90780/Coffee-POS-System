using Coffee_Shop_POS_System___EF_Core_6._0.Domain;
using Microsoft.EntityFrameworkCore;

namespace Coffee_Shop_POS_System___EF_Core_6._0;

internal class DatabaseModel : DbContext
{
    public DbSet<Categories> Categories { get; set; }
    public DbSet<Product> ProductCatalogues { get; set; }
    public DbSet<ProductProperties> ProductVariants { get; set; }
    public DbSet<CustomerOrder> CustomerOrders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Linux Machine
        //optionsBuilder.UseSqlite(@"Data Source=/home/davidnguyen/Documents/Coffee Shop POS System/CoffeeShopDB.db");

        //Windows Machine
        optionsBuilder.UseSqlite(@"Data Source=C:\Users\David Nguyen\Documents\Git Repositories\Coffee-POS-System\CoffeeShopDB.db");//.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
}
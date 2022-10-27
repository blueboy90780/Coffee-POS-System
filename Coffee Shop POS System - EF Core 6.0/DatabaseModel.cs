using Coffee_Shop_POS_System___EF_Core_6._0.Domain;
using Microsoft.EntityFrameworkCore;

namespace Coffee_Shop_POS_System___EF_Core_6._0;

internal class DatabaseModel : DbContext
{
    public DbSet<Categories> Categories { get; set; }
    public DbSet<ProductCatalogue> ProductCatalogues { get; set; }
    public DbSet<ProductProperties> ProductProperties { get; set; }
    public DbSet<CustomerOrder> CustomerOrders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(
            @"Data Source=/home/davidnguyen/Documents/Coffee-POS-System/Coffee Shop POS System - EF Core 6.0/CoffeeShopDB.db"); //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
}
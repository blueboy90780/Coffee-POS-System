using Microsoft.EntityFrameworkCore;

namespace CoffeeShop_POS_Project_with_EF_Core;

internal class MenuContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var workingDirectory = Environment.CurrentDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory)!.Parent!.Parent!.FullName!;
        optionsBuilder.UseSqlite($"Data Source={projectDirectory}" + @"\CoffeeShopDB.db");
    }
}
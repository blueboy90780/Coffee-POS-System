using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShop_POS_Project_with_EF_Core.Migrations
{
    public partial class ProductVariation_Patch2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductSize",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "ProductVariants",
                newName: "ProductSize");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductSize",
                table: "ProductVariants",
                newName: "Size");

            migrationBuilder.AddColumn<int>(
                name: "ProductSize",
                table: "Products",
                type: "INTEGER",
                nullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShop_POS_Project_with_EF_Core.Migrations
{
    public partial class Main_Patch1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product Catalogue_CategoryId",
                table: "Product Catalogue");

            migrationBuilder.CreateIndex(
                name: "IX_Product Catalogue_CategoryId",
                table: "Product Catalogue",
                column: "CategoryId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product Catalogue_CategoryId",
                table: "Product Catalogue");

            migrationBuilder.CreateIndex(
                name: "IX_Product Catalogue_CategoryId",
                table: "Product Catalogue",
                column: "CategoryId");
        }
    }
}

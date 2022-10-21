using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShop_POS_Project_with_EF_Core.Migrations
{
    public partial class Database_Patch6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product Catalogue_Categories_CategoriesId",
                table: "Product Catalogue");

            migrationBuilder.DropIndex(
                name: "IX_Product Catalogue_CategoriesId",
                table: "Product Catalogue");

            migrationBuilder.DropColumn(
                name: "CategoriesId",
                table: "Product Catalogue");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Product Catalogue",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product Catalogue_CategoryId",
                table: "Product Catalogue",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product Catalogue_Categories_CategoryId",
                table: "Product Catalogue",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoriesId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product Catalogue_Categories_CategoryId",
                table: "Product Catalogue");

            migrationBuilder.DropIndex(
                name: "IX_Product Catalogue_CategoryId",
                table: "Product Catalogue");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Product Catalogue");

            migrationBuilder.AddColumn<int>(
                name: "CategoriesId",
                table: "Product Catalogue",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product Catalogue_CategoriesId",
                table: "Product Catalogue",
                column: "CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product Catalogue_Categories_CategoriesId",
                table: "Product Catalogue",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "CategoriesId");
        }
    }
}

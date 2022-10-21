using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShop_POS_Project_with_EF_Core.Migrations
{
    public partial class Main_Patch2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product Catalogue_Categories_CategoryId",
                table: "Product Catalogue");

            migrationBuilder.DropIndex(
                name: "IX_Product Catalogue_CategoryId",
                table: "Product Catalogue");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Product Catalogue",
                newName: "CategoriesId");

            migrationBuilder.AlterColumn<bool>(
                name: "IceAvailable",
                table: "Categories",
                type: "INTEGER",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product Catalogue_CategoriesId",
                table: "Product Catalogue",
                column: "CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product Catalogue_Categories_CategoriesId",
                table: "Product Catalogue",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "CategoriesId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product Catalogue_Categories_CategoriesId",
                table: "Product Catalogue");

            migrationBuilder.DropIndex(
                name: "IX_Product Catalogue_CategoriesId",
                table: "Product Catalogue");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "Product Catalogue",
                newName: "CategoryId");

            migrationBuilder.AlterColumn<bool>(
                name: "IceAvailable",
                table: "Categories",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Product Catalogue_CategoryId",
                table: "Product Catalogue",
                column: "CategoryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product Catalogue_Categories_CategoryId",
                table: "Product Catalogue",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoriesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

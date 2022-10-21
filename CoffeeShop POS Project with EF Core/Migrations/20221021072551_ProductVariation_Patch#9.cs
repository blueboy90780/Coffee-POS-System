using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShop_POS_Project_with_EF_Core.Migrations
{
    public partial class ProductVariation_Patch9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_ProductCatalogue_ProductCatalogueId",
                table: "ProductVariants");

            migrationBuilder.RenameColumn(
                name: "ProductCatalogueId",
                table: "ProductVariants",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductVariants_ProductCatalogueId",
                table: "ProductVariants",
                newName: "IX_ProductVariants_ProductId");

            migrationBuilder.RenameColumn(
                name: "ProductCatalogueId",
                table: "ProductCatalogue",
                newName: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_ProductCatalogue_ProductId",
                table: "ProductVariants",
                column: "ProductId",
                principalTable: "ProductCatalogue",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_ProductCatalogue_ProductId",
                table: "ProductVariants");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductVariants",
                newName: "ProductCatalogueId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductVariants_ProductId",
                table: "ProductVariants",
                newName: "IX_ProductVariants_ProductCatalogueId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductCatalogue",
                newName: "ProductCatalogueId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_ProductCatalogue_ProductCatalogueId",
                table: "ProductVariants",
                column: "ProductCatalogueId",
                principalTable: "ProductCatalogue",
                principalColumn: "ProductCatalogueId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

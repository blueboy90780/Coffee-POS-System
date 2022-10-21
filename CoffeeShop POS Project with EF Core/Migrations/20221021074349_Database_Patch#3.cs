using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShop_POS_Project_with_EF_Core.Migrations
{
    public partial class Database_Patch3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrder_ProductCatalogue_AvailableProductsProductId",
                table: "CustomerOrder");

            migrationBuilder.RenameColumn(
                name: "ProductVariantsId",
                table: "ProductVariants",
                newName: "ProductPropertiesId");

            migrationBuilder.RenameColumn(
                name: "AvailableProductsProductId",
                table: "CustomerOrder",
                newName: "ProductPropertiesId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerOrder_AvailableProductsProductId",
                table: "CustomerOrder",
                newName: "IX_CustomerOrder_ProductPropertiesId");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "CustomerOrder",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrder_ProductId",
                table: "CustomerOrder",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrder_ProductCatalogue_ProductId",
                table: "CustomerOrder",
                column: "ProductId",
                principalTable: "ProductCatalogue",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrder_ProductVariants_ProductPropertiesId",
                table: "CustomerOrder",
                column: "ProductPropertiesId",
                principalTable: "ProductVariants",
                principalColumn: "ProductPropertiesId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrder_ProductCatalogue_ProductId",
                table: "CustomerOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrder_ProductVariants_ProductPropertiesId",
                table: "CustomerOrder");

            migrationBuilder.DropIndex(
                name: "IX_CustomerOrder_ProductId",
                table: "CustomerOrder");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "CustomerOrder");

            migrationBuilder.RenameColumn(
                name: "ProductPropertiesId",
                table: "ProductVariants",
                newName: "ProductVariantsId");

            migrationBuilder.RenameColumn(
                name: "ProductPropertiesId",
                table: "CustomerOrder",
                newName: "AvailableProductsProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerOrder_ProductPropertiesId",
                table: "CustomerOrder",
                newName: "IX_CustomerOrder_AvailableProductsProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrder_ProductCatalogue_AvailableProductsProductId",
                table: "CustomerOrder",
                column: "AvailableProductsProductId",
                principalTable: "ProductCatalogue",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

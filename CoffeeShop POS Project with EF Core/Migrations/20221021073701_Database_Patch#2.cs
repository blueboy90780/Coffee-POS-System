using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShop_POS_Project_with_EF_Core.Migrations
{
    public partial class Database_Patch2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCatalogue_CustomerOrder_CustomerOrderId",
                table: "ProductCatalogue");

            migrationBuilder.DropIndex(
                name: "IX_ProductCatalogue_CustomerOrderId",
                table: "ProductCatalogue");

            migrationBuilder.DropColumn(
                name: "CustomerOrderId",
                table: "ProductCatalogue");

            migrationBuilder.AddColumn<int>(
                name: "AvailableProductsProductId",
                table: "CustomerOrder",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrder_AvailableProductsProductId",
                table: "CustomerOrder",
                column: "AvailableProductsProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrder_ProductCatalogue_AvailableProductsProductId",
                table: "CustomerOrder",
                column: "AvailableProductsProductId",
                principalTable: "ProductCatalogue",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrder_ProductCatalogue_AvailableProductsProductId",
                table: "CustomerOrder");

            migrationBuilder.DropIndex(
                name: "IX_CustomerOrder_AvailableProductsProductId",
                table: "CustomerOrder");

            migrationBuilder.DropColumn(
                name: "AvailableProductsProductId",
                table: "CustomerOrder");

            migrationBuilder.AddColumn<int>(
                name: "CustomerOrderId",
                table: "ProductCatalogue",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCatalogue_CustomerOrderId",
                table: "ProductCatalogue",
                column: "CustomerOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCatalogue_CustomerOrder_CustomerOrderId",
                table: "ProductCatalogue",
                column: "CustomerOrderId",
                principalTable: "CustomerOrder",
                principalColumn: "CustomerOrderId");
        }
    }
}

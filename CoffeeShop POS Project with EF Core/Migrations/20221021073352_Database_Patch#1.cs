using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShop_POS_Project_with_EF_Core.Migrations
{
    public partial class Database_Patch1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrder_ProductVariants_ProductVariantsId",
                table: "CustomerOrder");

            migrationBuilder.DropIndex(
                name: "IX_CustomerOrder_ProductVariantsId",
                table: "CustomerOrder");

            migrationBuilder.DropColumn(
                name: "ProductVariantsId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "ProductVariantsId",
                table: "CustomerOrder",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrder_ProductVariantsId",
                table: "CustomerOrder",
                column: "ProductVariantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrder_ProductVariants_ProductVariantsId",
                table: "CustomerOrder",
                column: "ProductVariantsId",
                principalTable: "ProductVariants",
                principalColumn: "ProductVariantsId");
        }
    }
}

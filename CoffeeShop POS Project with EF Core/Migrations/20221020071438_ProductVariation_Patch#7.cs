using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShop_POS_Project_with_EF_Core.Migrations
{
    public partial class ProductVariation_Patch7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_CustomerOrder_CustomerOrderId",
                table: "ProductVariants");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariants_CustomerOrderId",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "CustomerOrderId",
                table: "ProductVariants");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "ProductVariants",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_CustomerOrderId",
                table: "ProductVariants",
                column: "CustomerOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_CustomerOrder_CustomerOrderId",
                table: "ProductVariants",
                column: "CustomerOrderId",
                principalTable: "CustomerOrder",
                principalColumn: "CustomerOrderId");
        }
    }
}

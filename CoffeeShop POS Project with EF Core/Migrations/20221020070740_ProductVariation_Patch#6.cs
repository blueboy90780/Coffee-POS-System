using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShop_POS_Project_with_EF_Core.Migrations
{
    public partial class ProductVariation_Patch6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerOrderId",
                table: "ProductVariants",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerOrder",
                columns: table => new
                {
                    CustomerOrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantity = table.Column<uint>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrder", x => x.CustomerOrderId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_CustomerOrder_CustomerOrderId",
                table: "ProductVariants");

            migrationBuilder.DropTable(
                name: "CustomerOrder");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariants_CustomerOrderId",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "CustomerOrderId",
                table: "ProductVariants");
        }
    }
}

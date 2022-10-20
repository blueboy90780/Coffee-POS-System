using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShop_POS_Project_with_EF_Core.Migrations
{
    public partial class ProductVariation_Patch5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_Products_ProductId",
                table: "ProductVariants");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductVariants",
                newName: "ProductCatalogueId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductVariants_ProductId",
                table: "ProductVariants",
                newName: "IX_ProductVariants_ProductCatalogueId");

            migrationBuilder.CreateTable(
                name: "ProductCatalogue",
                columns: table => new
                {
                    ProductCatalogueId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ENname = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: false),
                    VNname = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Recommended = table.Column<bool>(type: "INTEGER", nullable: false),
                    CategoriesId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCatalogue", x => x.ProductCatalogueId);
                    table.ForeignKey(
                        name: "FK_ProductCatalogue_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "CategoriesId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCatalogue_CategoriesId",
                table: "ProductCatalogue",
                column: "CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_ProductCatalogue_ProductCatalogueId",
                table: "ProductVariants",
                column: "ProductCatalogueId",
                principalTable: "ProductCatalogue",
                principalColumn: "ProductCatalogueId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_ProductCatalogue_ProductCatalogueId",
                table: "ProductVariants");

            migrationBuilder.DropTable(
                name: "ProductCatalogue");

            migrationBuilder.RenameColumn(
                name: "ProductCatalogueId",
                table: "ProductVariants",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductVariants_ProductCatalogueId",
                table: "ProductVariants",
                newName: "IX_ProductVariants_ProductId");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoriesId = table.Column<int>(type: "INTEGER", nullable: true),
                    ENname = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: false),
                    Recommended = table.Column<bool>(type: "INTEGER", nullable: false),
                    VNname = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "CategoriesId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoriesId",
                table: "Products",
                column: "CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_Products_ProductId",
                table: "ProductVariants",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

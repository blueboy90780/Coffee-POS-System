using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coffee_Shop_POS_System___EF_Core_6._0.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false),
                    IceAvailable = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoriesId);
                });

            migrationBuilder.CreateTable(
                name: "ProductCatalogues",
                columns: table => new
                {
                    ProductCatalogueId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ENname = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: false),
                    VNname = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Recommended = table.Column<bool>(type: "INTEGER", nullable: false),
                    CategoriesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCatalogues", x => x.ProductCatalogueId);
                    table.ForeignKey(
                        name: "FK_ProductCatalogues_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "CategoriesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    ProductPropertiesId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<uint>(type: "INTEGER", nullable: false),
                    ProductSize = table.Column<int>(type: "INTEGER", nullable: true),
                    Volume = table.Column<float>(type: "REAL", nullable: true),
                    ProductCatalogueId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => x.ProductPropertiesId);
                    table.ForeignKey(
                        name: "FK_ProductVariants_ProductCatalogues_ProductCatalogueId",
                        column: x => x.ProductCatalogueId,
                        principalTable: "ProductCatalogues",
                        principalColumn: "ProductCatalogueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrders",
                columns: table => new
                {
                    CustomerOrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductCatalogueId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductPropertiesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrders", x => x.CustomerOrderId);
                    table.ForeignKey(
                        name: "FK_CustomerOrders_ProductCatalogues_ProductCatalogueId",
                        column: x => x.ProductCatalogueId,
                        principalTable: "ProductCatalogues",
                        principalColumn: "ProductCatalogueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerOrders_ProductVariants_ProductPropertiesId",
                        column: x => x.ProductPropertiesId,
                        principalTable: "ProductVariants",
                        principalColumn: "ProductPropertiesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_ProductCatalogueId",
                table: "CustomerOrders",
                column: "ProductCatalogueId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_ProductPropertiesId",
                table: "CustomerOrders",
                column: "ProductPropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCatalogues_CategoriesId",
                table: "ProductCatalogues",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductCatalogueId",
                table: "ProductVariants",
                column: "ProductCatalogueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerOrders");

            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "ProductCatalogues");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

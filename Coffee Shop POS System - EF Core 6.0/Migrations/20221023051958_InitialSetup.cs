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
                name: "Customer Order Menu",
                columns: table => new
                {
                    CustomerOrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer Order Menu", x => x.CustomerOrderId);
                });

            migrationBuilder.CreateTable(
                name: "Product Catalogue",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ENname = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: false),
                    VNname = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Recommended = table.Column<bool>(type: "INTEGER", nullable: false),
                    CategoriesId = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerOrderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product Catalogue", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product Catalogue_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "CategoriesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product Catalogue_Customer Order Menu_CustomerOrderId",
                        column: x => x.CustomerOrderId,
                        principalTable: "Customer Order Menu",
                        principalColumn: "CustomerOrderId");
                });

            migrationBuilder.CreateTable(
                name: "Product Properties",
                columns: table => new
                {
                    ProductPropertiesId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<uint>(type: "INTEGER", nullable: false),
                    ProductSize = table.Column<int>(type: "INTEGER", nullable: true),
                    Volume = table.Column<float>(type: "REAL", nullable: true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerOrderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product Properties", x => x.ProductPropertiesId);
                    table.ForeignKey(
                        name: "FK_Product Properties_Customer Order Menu_CustomerOrderId",
                        column: x => x.CustomerOrderId,
                        principalTable: "Customer Order Menu",
                        principalColumn: "CustomerOrderId");
                    table.ForeignKey(
                        name: "FK_Product Properties_Product Catalogue_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product Catalogue",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product Catalogue_CategoriesId",
                table: "Product Catalogue",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Product Catalogue_CustomerOrderId",
                table: "Product Catalogue",
                column: "CustomerOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Product Properties_CustomerOrderId",
                table: "Product Properties",
                column: "CustomerOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Product Properties_ProductId",
                table: "Product Properties",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product Properties");

            migrationBuilder.DropTable(
                name: "Product Catalogue");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Customer Order Menu");
        }
    }
}

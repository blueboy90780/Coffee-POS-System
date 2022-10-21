using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShop_POS_Project_with_EF_Core.Migrations
{
    public partial class Database_Patch4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrder_ProductCatalogue_ProductId",
                table: "CustomerOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrder_ProductVariants_ProductPropertiesId",
                table: "CustomerOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCatalogue_Categories_CategoriesId",
                table: "ProductCatalogue");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_ProductCatalogue_ProductId",
                table: "ProductVariants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductVariants",
                table: "ProductVariants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCatalogue",
                table: "ProductCatalogue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerOrder",
                table: "CustomerOrder");

            migrationBuilder.RenameTable(
                name: "ProductVariants",
                newName: "Product Properties");

            migrationBuilder.RenameTable(
                name: "ProductCatalogue",
                newName: "Product Catalogue");

            migrationBuilder.RenameTable(
                name: "CustomerOrder",
                newName: "Customer Order Menu");

            migrationBuilder.RenameIndex(
                name: "IX_ProductVariants_ProductId",
                table: "Product Properties",
                newName: "IX_Product Properties_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCatalogue_CategoriesId",
                table: "Product Catalogue",
                newName: "IX_Product Catalogue_CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerOrder_ProductPropertiesId",
                table: "Customer Order Menu",
                newName: "IX_Customer Order Menu_ProductPropertiesId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerOrder_ProductId",
                table: "Customer Order Menu",
                newName: "IX_Customer Order Menu_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product Properties",
                table: "Product Properties",
                column: "ProductPropertiesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product Catalogue",
                table: "Product Catalogue",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer Order Menu",
                table: "Customer Order Menu",
                column: "CustomerOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer Order Menu_Product Catalogue_ProductId",
                table: "Customer Order Menu",
                column: "ProductId",
                principalTable: "Product Catalogue",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer Order Menu_Product Properties_ProductPropertiesId",
                table: "Customer Order Menu",
                column: "ProductPropertiesId",
                principalTable: "Product Properties",
                principalColumn: "ProductPropertiesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product Catalogue_Categories_CategoriesId",
                table: "Product Catalogue",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product Properties_Product Catalogue_ProductId",
                table: "Product Properties",
                column: "ProductId",
                principalTable: "Product Catalogue",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer Order Menu_Product Catalogue_ProductId",
                table: "Customer Order Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer Order Menu_Product Properties_ProductPropertiesId",
                table: "Customer Order Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Product Catalogue_Categories_CategoriesId",
                table: "Product Catalogue");

            migrationBuilder.DropForeignKey(
                name: "FK_Product Properties_Product Catalogue_ProductId",
                table: "Product Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product Properties",
                table: "Product Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product Catalogue",
                table: "Product Catalogue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer Order Menu",
                table: "Customer Order Menu");

            migrationBuilder.RenameTable(
                name: "Product Properties",
                newName: "ProductVariants");

            migrationBuilder.RenameTable(
                name: "Product Catalogue",
                newName: "ProductCatalogue");

            migrationBuilder.RenameTable(
                name: "Customer Order Menu",
                newName: "CustomerOrder");

            migrationBuilder.RenameIndex(
                name: "IX_Product Properties_ProductId",
                table: "ProductVariants",
                newName: "IX_ProductVariants_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Product Catalogue_CategoriesId",
                table: "ProductCatalogue",
                newName: "IX_ProductCatalogue_CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer Order Menu_ProductPropertiesId",
                table: "CustomerOrder",
                newName: "IX_CustomerOrder_ProductPropertiesId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer Order Menu_ProductId",
                table: "CustomerOrder",
                newName: "IX_CustomerOrder_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductVariants",
                table: "ProductVariants",
                column: "ProductPropertiesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCatalogue",
                table: "ProductCatalogue",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerOrder",
                table: "CustomerOrder",
                column: "CustomerOrderId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCatalogue_Categories_CategoriesId",
                table: "ProductCatalogue",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_ProductCatalogue_ProductId",
                table: "ProductVariants",
                column: "ProductId",
                principalTable: "ProductCatalogue",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

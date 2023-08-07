using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreatingTables.Migrations
{
    /// <inheritdoc />
    public partial class SmallChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productDetails_Products_ProductId",
                table: "productDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productDetails",
                table: "productDetails");

            migrationBuilder.RenameTable(
                name: "productDetails",
                newName: "ProductDetails");

            migrationBuilder.RenameIndex(
                name: "IX_productDetails_ProductId",
                table: "ProductDetails",
                newName: "IX_ProductDetails_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDetails",
                table: "ProductDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Products_ProductId",
                table: "ProductDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Products_ProductId",
                table: "ProductDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDetails",
                table: "ProductDetails");

            migrationBuilder.RenameTable(
                name: "ProductDetails",
                newName: "productDetails");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDetails_ProductId",
                table: "productDetails",
                newName: "IX_productDetails_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productDetails",
                table: "productDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_productDetails_Products_ProductId",
                table: "productDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

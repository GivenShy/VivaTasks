using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreatingTables.Migrations
{
    /// <inheritdoc />
    public partial class deleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BestSellerProducts_BestSellerProductId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_FeaturedProducts_FeaturedProductId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "BestSellerProducts");

            migrationBuilder.DropTable(
                name: "FeaturedProducts");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BestSellerProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FeaturedProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BestSellerProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FeaturedProductId",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BestSellerProductId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeaturedProductId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BestSellerProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductDetailsId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BestSellerProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BestSellerProducts_ProductDetails_ProductDetailsId",
                        column: x => x.ProductDetailsId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeaturedProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductDetailsId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeaturedProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeaturedProducts_ProductDetails_ProductDetailsId",
                        column: x => x.ProductDetailsId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BestSellerProductId",
                table: "Orders",
                column: "BestSellerProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FeaturedProductId",
                table: "Orders",
                column: "FeaturedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BestSellerProducts_ProductDetailsId",
                table: "BestSellerProducts",
                column: "ProductDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_FeaturedProducts_ProductDetailsId",
                table: "FeaturedProducts",
                column: "ProductDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_BestSellerProducts_BestSellerProductId",
                table: "Orders",
                column: "BestSellerProductId",
                principalTable: "BestSellerProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_FeaturedProducts_FeaturedProductId",
                table: "Orders",
                column: "FeaturedProductId",
                principalTable: "FeaturedProducts",
                principalColumn: "Id");
        }
    }
}

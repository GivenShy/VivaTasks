using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreatingTables.Migrations
{
    /// <inheritdoc />
    public partial class addedNewCustomersAndBestSellerProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BestSellerProductId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NewCustomerId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BestSellerProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDetailsId = table.Column<int>(type: "int", nullable: false)
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
                name: "NewCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewCustomers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BestSellerProductId",
                table: "Orders",
                column: "BestSellerProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_NewCustomerId",
                table: "Orders",
                column: "NewCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BestSellerProducts_ProductDetailsId",
                table: "BestSellerProducts",
                column: "ProductDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_BestSellerProducts_BestSellerProductId",
                table: "Orders",
                column: "BestSellerProductId",
                principalTable: "BestSellerProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_NewCustomers_NewCustomerId",
                table: "Orders",
                column: "NewCustomerId",
                principalTable: "NewCustomers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BestSellerProducts_BestSellerProductId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_NewCustomers_NewCustomerId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "BestSellerProducts");

            migrationBuilder.DropTable(
                name: "NewCustomers");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BestSellerProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_NewCustomerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BestSellerProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "NewCustomerId",
                table: "Orders");
        }
    }
}

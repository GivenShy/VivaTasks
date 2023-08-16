using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreatingTables.Migrations
{
    /// <inheritdoc />
    public partial class addedFeaturedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeaturedProductId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "NewCustomers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_NewCustomers_Email",
                table: "NewCustomers",
                column: "Email");

            migrationBuilder.CreateTable(
                name: "FeaturedProducts",
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
                    table.PrimaryKey("PK_FeaturedProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeaturedProducts_ProductDetails_ProductDetailsId",
                        column: x => x.ProductDetailsId,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FeaturedProductId",
                table: "Orders",
                column: "FeaturedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FeaturedProducts_ProductDetailsId",
                table: "FeaturedProducts",
                column: "ProductDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_FeaturedProducts_FeaturedProductId",
                table: "Orders",
                column: "FeaturedProductId",
                principalTable: "FeaturedProducts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_FeaturedProducts_FeaturedProductId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "FeaturedProducts");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FeaturedProductId",
                table: "Orders");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_NewCustomers_Email",
                table: "NewCustomers");

            migrationBuilder.DropColumn(
                name: "FeaturedProductId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "NewCustomers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreatingTables.Migrations
{
    /// <inheritdoc />
    public partial class rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CutomerId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "CutomerId",
                table: "Orders",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_Status_CutomerId",
                table: "Orders",
                newName: "IX_Orders_Status_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CutomerId",
                table: "Orders",
                newName: "IX_Orders_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Orders",
                newName: "CutomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_Status_CustomerId",
                table: "Orders",
                newName: "IX_Orders_Status_CutomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                newName: "IX_Orders_CutomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CutomerId",
                table: "Orders",
                column: "CutomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

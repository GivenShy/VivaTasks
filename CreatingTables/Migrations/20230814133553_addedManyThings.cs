using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreatingTables.Migrations
{
    /// <inheritdoc />
    public partial class addedManyThings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "avarageTime",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "CallDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CallDetails_CustomerId",
                table: "CallDetails",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CallDetails_Customers_CustomerId",
                table: "CallDetails",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CallDetails_Customers_CustomerId",
                table: "CallDetails");

            migrationBuilder.DropIndex(
                name: "IX_CallDetails_CustomerId",
                table: "CallDetails");

            migrationBuilder.DropColumn(
                name: "avarageTime",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CallDetails");
        }
    }
}

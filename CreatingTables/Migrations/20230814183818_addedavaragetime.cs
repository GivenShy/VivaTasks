using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreatingTables.Migrations
{
    /// <inheritdoc />
    public partial class addedavaragetime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvarageCallTime",
                table: "CallDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MyOutput",
                columns: table => new
                {
                    Result = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyOutput");

            migrationBuilder.DropColumn(
                name: "AvarageCallTime",
                table: "CallDetails");
        }
    }
}

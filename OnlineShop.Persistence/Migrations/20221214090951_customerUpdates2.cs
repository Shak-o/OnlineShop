using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class customerUpdates2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccoutnId",
                schema: "SalesLT",
                table: "Customer");

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                schema: "SalesLT",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                schema: "SalesLT",
                table: "Customer");

            migrationBuilder.AddColumn<string>(
                name: "AccoutnId",
                schema: "SalesLT",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

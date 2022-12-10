using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addressId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                schema: "SalesLT",
                table: "Customer",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                comment: "Date and time the record was last updated.",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Date and time the record was last updated.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                schema: "SalesLT",
                table: "Address",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                comment: "Date and time the record was last updated.",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(getdate())",
                oldComment: "Date and time the record was last updated.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                schema: "SalesLT",
                table: "Customer",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Date and time the record was last updated.",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()",
                oldComment: "Date and time the record was last updated.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                schema: "SalesLT",
                table: "Address",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                comment: "Date and time the record was last updated.",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()",
                oldComment: "Date and time the record was last updated.");
        }
    }
}

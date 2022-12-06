using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                schema: "SalesLT",
                table: "Customer",
                type: "varchar(300)",
                unicode: false,
                maxLength: 300,
                nullable: false,
                comment: "Password for the e-mail account.",
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldUnicode: false,
                oldMaxLength: 128,
                oldComment: "Password for the e-mail account.");

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
                oldDefaultValueSql: "(getdate())",
                oldComment: "Date and time the record was last updated.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                schema: "SalesLT",
                table: "Customer",
                type: "varchar(128)",
                unicode: false,
                maxLength: 128,
                nullable: false,
                comment: "Password for the e-mail account.",
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldUnicode: false,
                oldMaxLength: 300,
                oldComment: "Password for the e-mail account.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                schema: "SalesLT",
                table: "Customer",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                comment: "Date and time the record was last updated.",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Date and time the record was last updated.");
        }
    }
}

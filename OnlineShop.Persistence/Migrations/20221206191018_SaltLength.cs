using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SaltLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordSalt",
                schema: "SalesLT",
                table: "Customer",
                type: "varchar(150)",
                unicode: false,
                maxLength: 150,
                nullable: false,
                comment: "Random value concatenated with the password string before the password is hashed.",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldUnicode: false,
                oldMaxLength: 10,
                oldComment: "Random value concatenated with the password string before the password is hashed.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordSalt",
                schema: "SalesLT",
                table: "Customer",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                comment: "Random value concatenated with the password string before the password is hashed.",
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldUnicode: false,
                oldMaxLength: 150,
                oldComment: "Random value concatenated with the password string before the password is hashed.");
        }
    }
}

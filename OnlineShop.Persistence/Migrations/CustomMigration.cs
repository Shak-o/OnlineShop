using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Persistence.Migrations
{
    public class CustomMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "PasswordHash",
                "Customer",
                "SalesLT"
            );

            migrationBuilder.DropColumn(
                "PasswordSalt",
                "Customer",
                "SalesLT"
            );
        }
    }
}

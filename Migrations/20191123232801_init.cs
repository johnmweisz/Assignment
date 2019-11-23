using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Registered = table.Column<DateTime>(nullable: false),
                    DayOne = table.Column<bool>(nullable: false),
                    DayTwo = table.Column<bool>(nullable: false),
                    DayThree = table.Column<bool>(nullable: false),
                    Request = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}

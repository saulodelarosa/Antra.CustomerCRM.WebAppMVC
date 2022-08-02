using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerCRM.Infrastructure.Migrations
{
    public partial class CustomerTableNewEmp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "Varchar(20)", nullable: false),
                    LastName = table.Column<string>(type: "Varchar(20)", nullable: false),
                    Title = table.Column<string>(type: "Varchar(50)", nullable: false),
                    TitleOfCourtesy = table.Column<string>(type: "Varchar(5)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    Address = table.Column<string>(type: "Varchar(80)", nullable: false),
                    City = table.Column<string>(type: "Varchar(20)", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "Varchar(20)", nullable: false),
                    Phone = table.Column<string>(type: "Varchar(15)", nullable: false),
                    ReportsTo = table.Column<int>(type: "int", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}

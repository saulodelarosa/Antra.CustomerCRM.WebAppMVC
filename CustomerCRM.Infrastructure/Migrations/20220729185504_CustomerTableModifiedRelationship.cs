using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerCRM.Infrastructure.Migrations
{
    public partial class CustomerTableModifiedRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customer_RegionId",
                table: "Customer",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Region_RegionId",
                table: "Customer",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Region_RegionId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_RegionId",
                table: "Customer");
        }
    }
}

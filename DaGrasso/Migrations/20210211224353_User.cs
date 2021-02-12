using Microsoft.EntityFrameworkCore.Migrations;

namespace DaGrasso.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20d9ed4e-b0e8-449d-b937-7c3d90b722c2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3f778027-948b-4647-a3e6-f090e51a4dbd", "401365c2-4234-4bab-b84e-c487e1d2d9aa", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f778027-948b-4647-a3e6-f090e51a4dbd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "20d9ed4e-b0e8-449d-b937-7c3d90b722c2", "b00e522b-6f50-48f9-b6e0-efb17ec31960", "Admin", "ADMIN" });
        }
    }
}

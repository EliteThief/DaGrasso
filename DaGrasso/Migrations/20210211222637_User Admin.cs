using Microsoft.EntityFrameworkCore.Migrations;

namespace DaGrasso.Migrations
{
    public partial class UserAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1c4f6de-6c28-45fe-96f8-623455da2662");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "20d9ed4e-b0e8-449d-b937-7c3d90b722c2", "b00e522b-6f50-48f9-b6e0-efb17ec31960", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20d9ed4e-b0e8-449d-b937-7c3d90b722c2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b1c4f6de-6c28-45fe-96f8-623455da2662", "de70d53f-1fb9-4f2f-b067-d135d13a91fa", "Admin", "ADMIN" });
        }
    }
}

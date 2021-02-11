using Microsoft.EntityFrameworkCore.Migrations;

namespace DaGrasso.Migrations
{
    public partial class UserHardcoded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abb53858-4ddb-4e52-a4c9-40ae3ea45924");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b1c4f6de-6c28-45fe-96f8-623455da2662", "de70d53f-1fb9-4f2f-b067-d135d13a91fa", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1c4f6de-6c28-45fe-96f8-623455da2662");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "abb53858-4ddb-4e52-a4c9-40ae3ea45924", "012819d6-e40c-4b89-9c2a-c756eee8e797", "Admin", "ADMIN" });
        }
    }
}

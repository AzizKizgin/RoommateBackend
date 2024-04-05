using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RoommateBackend.Migrations
{
    /// <inheritdoc />
    public partial class user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19af69d5-f0e8-4f3c-a16e-3e4aca6b56b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a111938-4835-4bb6-a79f-073af734a37a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f5ef61b-65f6-45b1-8992-a90148b40976", null, "User", "USER" },
                    { "b73a7c7d-b5e2-47a1-86c0-210b7fbf8c9c", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f5ef61b-65f6-45b1-8992-a90148b40976");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b73a7c7d-b5e2-47a1-86c0-210b7fbf8c9c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19af69d5-f0e8-4f3c-a16e-3e4aca6b56b7", null, "Admin", "ADMIN" },
                    { "3a111938-4835-4bb6-a79f-073af734a37a", null, "User", "USER" }
                });
        }
    }
}

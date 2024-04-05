using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RoommateBackend.Migrations
{
    /// <inheritdoc />
    public partial class about : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f5ef61b-65f6-45b1-8992-a90148b40976");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b73a7c7d-b5e2-47a1-86c0-210b7fbf8c9c");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "AspNetUsers",
                newName: "About");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "59ed78c6-626d-4c0e-9b9c-e3d718d2b3e8", null, "Admin", "ADMIN" },
                    { "a54e62a8-6b81-4387-849c-2b67fe5a8614", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59ed78c6-626d-4c0e-9b9c-e3d718d2b3e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a54e62a8-6b81-4387-849c-2b67fe5a8614");

            migrationBuilder.RenameColumn(
                name: "About",
                table: "AspNetUsers",
                newName: "Description");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f5ef61b-65f6-45b1-8992-a90148b40976", null, "User", "USER" },
                    { "b73a7c7d-b5e2-47a1-86c0-210b7fbf8c9c", null, "Admin", "ADMIN" }
                });
        }
    }
}

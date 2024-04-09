using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RoommateBackend.Migrations
{
    /// <inheritdoc />
    public partial class RoomAbout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b96c1544-4031-4558-97cf-4634371648ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa306de4-7963-41ee-99cd-c9889b83e441");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Rooms",
                newName: "About");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bed6aab5-467a-4ee1-a2de-838835ad3430", null, "User", "USER" },
                    { "cd225a0b-6e1e-417d-9fcd-7a46cc1107e1", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bed6aab5-467a-4ee1-a2de-838835ad3430");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd225a0b-6e1e-417d-9fcd-7a46cc1107e1");

            migrationBuilder.RenameColumn(
                name: "About",
                table: "Rooms",
                newName: "Description");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b96c1544-4031-4558-97cf-4634371648ce", null, "User", "USER" },
                    { "fa306de4-7963-41ee-99cd-c9889b83e441", null, "Admin", "ADMIN" }
                });
        }
    }
}

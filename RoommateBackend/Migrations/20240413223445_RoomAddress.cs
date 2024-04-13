using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RoommateBackend.Migrations
{
    /// <inheritdoc />
    public partial class RoomAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "State",
                table: "RoomAddresses",
                newName: "Town");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "RoomAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5e34d7a6-5c74-4850-96ba-6516efe080e2", null, "User", "USER" },
                    { "e91ffbd4-337f-4ad9-9fbf-d87a8104a8c1", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e34d7a6-5c74-4850-96ba-6516efe080e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e91ffbd4-337f-4ad9-9fbf-d87a8104a8c1");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "RoomAddresses");

            migrationBuilder.RenameColumn(
                name: "Town",
                table: "RoomAddresses",
                newName: "State");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bed6aab5-467a-4ee1-a2de-838835ad3430", null, "User", "USER" },
                    { "cd225a0b-6e1e-417d-9fcd-7a46cc1107e1", null, "Admin", "ADMIN" }
                });
        }
    }
}

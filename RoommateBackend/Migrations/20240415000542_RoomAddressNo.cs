using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RoommateBackend.Migrations
{
    /// <inheritdoc />
    public partial class RoomAddressNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e34d7a6-5c74-4850-96ba-6516efe080e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e91ffbd4-337f-4ad9-9fbf-d87a8104a8c1");

            migrationBuilder.AddColumn<string>(
                name: "ApartmentNo",
                table: "RoomAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BuildingNo",
                table: "RoomAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "61cb3ea5-445a-442c-aed8-89216cfafd26", null, "Admin", "ADMIN" },
                    { "fc0b6422-fc19-4b74-bfe9-b9c4b20d1fdc", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61cb3ea5-445a-442c-aed8-89216cfafd26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc0b6422-fc19-4b74-bfe9-b9c4b20d1fdc");

            migrationBuilder.DropColumn(
                name: "ApartmentNo",
                table: "RoomAddresses");

            migrationBuilder.DropColumn(
                name: "BuildingNo",
                table: "RoomAddresses");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5e34d7a6-5c74-4850-96ba-6516efe080e2", null, "User", "USER" },
                    { "e91ffbd4-337f-4ad9-9fbf-d87a8104a8c1", null, "Admin", "ADMIN" }
                });
        }
    }
}

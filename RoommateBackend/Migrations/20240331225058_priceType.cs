using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RoommateBackend.Migrations
{
    /// <inheritdoc />
    public partial class priceType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6dd506b3-0706-413c-afb0-80cab4c0abda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af7d2f15-da74-422a-bdf4-d4ddf347861b");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Rooms",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3ff6606a-b388-4ced-bc3d-950848d8b6e6", null, "Admin", "ADMIN" },
                    { "8ff301bd-e69a-4f95-aeaf-062c704fbf70", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ff6606a-b388-4ced-bc3d-950848d8b6e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ff301bd-e69a-4f95-aeaf-062c704fbf70");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Rooms",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6dd506b3-0706-413c-afb0-80cab4c0abda", null, "User", "USER" },
                    { "af7d2f15-da74-422a-bdf4-d4ddf347861b", null, "Admin", "ADMIN" }
                });
        }
    }
}

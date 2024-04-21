using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RoommateBackend.Migrations
{
    /// <inheritdoc />
    public partial class dbContextUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_AspNetUsers_OwnerId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "SavedRooms");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61cb3ea5-445a-442c-aed8-89216cfafd26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc0b6422-fc19-4b74-bfe9-b9c4b20d1fdc");

            migrationBuilder.CreateTable(
                name: "UserSavedRooms",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    SavedOn = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSavedRooms", x => new { x.UserId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_UserSavedRooms_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSavedRooms_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "060199b4-f9a3-4132-a40d-0dee0d401507", null, "User", "USER" },
                    { "1d46f8fd-c27e-4eeb-bbbe-f2555274ec0b", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSavedRooms_RoomId",
                table: "UserSavedRooms",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_AspNetUsers_OwnerId",
                table: "Rooms",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_AspNetUsers_OwnerId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "UserSavedRooms");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "060199b4-f9a3-4132-a40d-0dee0d401507");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d46f8fd-c27e-4eeb-bbbe-f2555274ec0b");

            migrationBuilder.CreateTable(
                name: "SavedRooms",
                columns: table => new
                {
                    SavedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SavedRoomsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedRooms", x => new { x.SavedById, x.SavedRoomsId });
                    table.ForeignKey(
                        name: "FK_SavedRooms_AspNetUsers_SavedById",
                        column: x => x.SavedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SavedRooms_Rooms_SavedRoomsId",
                        column: x => x.SavedRoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "61cb3ea5-445a-442c-aed8-89216cfafd26", null, "Admin", "ADMIN" },
                    { "fc0b6422-fc19-4b74-bfe9-b9c4b20d1fdc", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SavedRooms_SavedRoomsId",
                table: "SavedRooms",
                column: "SavedRoomsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_AspNetUsers_OwnerId",
                table: "Rooms",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

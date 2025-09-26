using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainBoilerPlate.Migrations
{
    /// <inheritdoc />
    public partial class resetnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateOfBirth",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", maxLength: 64, nullable: false),
                    Token = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExpirationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 9, 26, 16, 51, 58, 37, DateTimeKind.Unspecified).AddTicks(7887), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 9, 26, 16, 51, 58, 37, DateTimeKind.Unspecified).AddTicks(7892), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 9, 26, 16, 51, 58, 37, DateTimeKind.Unspecified).AddTicks(7901), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 9, 26, 16, 51, 58, 37, DateTimeKind.Unspecified).AddTicks(7869), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 9, 26, 15, 0, 31, 983, DateTimeKind.Unspecified).AddTicks(9324), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 9, 26, 15, 0, 31, 983, DateTimeKind.Unspecified).AddTicks(9329), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 9, 26, 15, 0, 31, 983, DateTimeKind.Unspecified).AddTicks(9339), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 9, 26, 15, 0, 31, 983, DateTimeKind.Unspecified).AddTicks(9307), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}

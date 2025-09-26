using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainBoilerPlate.Migrations
{
    /// <inheritdoc />
    public partial class removeuselessfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Bookings_BookingId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_BookingId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Slots");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Bookings");

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
                columns: new[] { "CreatedAt", "Name", "NormalizedName" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 15, 0, 31, 983, DateTimeKind.Unspecified).AddTicks(9329), new TimeSpan(0, 0, 0, 0, 0)), "Teacher", "TEACHER" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 9, 26, 15, 0, 31, 983, DateTimeKind.Unspecified).AddTicks(9307), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ArchivedAt", "ConcurrencyStamp", "CreatedAt", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[] { new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"), null, null, new DateTimeOffset(new DateTime(2025, 9, 26, 15, 0, 31, 983, DateTimeKind.Unspecified).AddTicks(9339), new TimeSpan(0, 0, 0, 0, 0)), "Student", "STUDENT", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"));

            migrationBuilder.AddColumn<Guid>(
                name: "BookingId",
                table: "Slots",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BookingId",
                table: "Bookings",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 9, 26, 14, 18, 33, 932, DateTimeKind.Unspecified).AddTicks(4011), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "CreatedAt", "Name", "NormalizedName" },
                values: new object[] { new DateTimeOffset(new DateTime(2025, 9, 26, 14, 18, 33, 932, DateTimeKind.Unspecified).AddTicks(4016), new TimeSpan(0, 0, 0, 0, 0)), "User", "USER" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 9, 26, 14, 18, 33, 932, DateTimeKind.Unspecified).AddTicks(3988), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingId",
                table: "Bookings",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Bookings_BookingId",
                table: "Bookings",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }
    }
}

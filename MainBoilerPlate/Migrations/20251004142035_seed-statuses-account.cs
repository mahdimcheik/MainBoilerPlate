using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MainBoilerPlate.Migrations
{
    /// <inheritdoc />
    public partial class seedstatusesaccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "ArchivedAt", "Color", "CreatedAt", "Icon", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"), new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1364), "#ff69b4", new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1375), "", "Female", new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1362) },
                    { new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"), new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1384), "#ab69b4", new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1388), "", "Other", new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1384) },
                    { new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"), new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1379), "#fa69b4", new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1382), "", "Male", new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1378) }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1288));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1294));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1299));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1271));

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "ArchivedAt", "Color", "CreatedAt", "Icon", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"), new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1427), "#fa69b4", new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1430), "", "Confirmed", new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1426) },
                    { new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"), new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1432), "#ab69b4", new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1435), "", "Banned", new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1432) },
                    { new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"), new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1419), "#ff69b4", new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1423), "", "Pending", new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1418) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"));

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 4, 14, 1, 14, 223, DateTimeKind.Utc).AddTicks(8644));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 4, 14, 1, 14, 223, DateTimeKind.Utc).AddTicks(8650));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 4, 14, 1, 14, 223, DateTimeKind.Utc).AddTicks(8655));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 4, 14, 1, 14, 223, DateTimeKind.Utc).AddTicks(8624));
        }
    }
}

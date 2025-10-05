using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainBoilerPlate.Migrations
{
    /// <inheritdoc />
    public partial class newfieldsuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DataProcessingConsent",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PrivacyPolicyConsent",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 4, 19, 54, 10, 684, DateTimeKind.Utc).AddTicks(9742), new DateTime(2025, 10, 4, 19, 54, 10, 684, DateTimeKind.Utc).AddTicks(9746), new DateTime(2025, 10, 4, 19, 54, 10, 684, DateTimeKind.Utc).AddTicks(9741) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 4, 19, 54, 10, 684, DateTimeKind.Utc).AddTicks(9752), new DateTime(2025, 10, 4, 19, 54, 10, 684, DateTimeKind.Utc).AddTicks(9754), new DateTime(2025, 10, 4, 19, 54, 10, 684, DateTimeKind.Utc).AddTicks(9752) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 4, 19, 54, 10, 684, DateTimeKind.Utc).AddTicks(9749), new DateTime(2025, 10, 4, 19, 54, 10, 684, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 10, 4, 19, 54, 10, 684, DateTimeKind.Utc).AddTicks(9748) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 4, 19, 54, 10, 684, DateTimeKind.Utc).AddTicks(9671));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 4, 19, 54, 10, 684, DateTimeKind.Utc).AddTicks(9675));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 4, 19, 54, 10, 684, DateTimeKind.Utc).AddTicks(9677));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 4, 19, 54, 10, 684, DateTimeKind.Utc).AddTicks(9661));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 4, 19, 54, 10, 684, DateTimeKind.Utc).AddTicks(9915), new DateTime(2025, 10, 4, 19, 54, 10, 684, DateTimeKind.Utc).AddTicks(9916), new DateTime(2025, 10, 4, 19, 54, 10, 684, DateTimeKind.Utc).AddTicks(9914) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 4, 19, 54, 10, 684, DateTimeKind.Utc).AddTicks(9918), new DateTime(2025, 10, 4, 19, 54, 10, 684, DateTimeKind.Utc).AddTicks(9924), new DateTime(2025, 10, 4, 19, 54, 10, 684, DateTimeKind.Utc).AddTicks(9918) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 4, 19, 54, 10, 684, DateTimeKind.Utc).AddTicks(9863), new DateTime(2025, 10, 4, 19, 54, 10, 684, DateTimeKind.Utc).AddTicks(9865), new DateTime(2025, 10, 4, 19, 54, 10, 684, DateTimeKind.Utc).AddTicks(9863) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataProcessingConsent",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PrivacyPolicyConsent",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1364), new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1375), new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1362) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1384), new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1388), new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1384) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1379), new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1382), new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1378) });

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

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1427), new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1430), new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1426) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1432), new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1435), new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1432) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1419), new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1423), new DateTime(2025, 10, 4, 14, 20, 34, 770, DateTimeKind.Utc).AddTicks(1418) });
        }
    }
}

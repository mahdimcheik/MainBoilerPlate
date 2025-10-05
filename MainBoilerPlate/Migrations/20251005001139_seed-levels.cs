using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MainBoilerPlate.Migrations
{
    /// <inheritdoc />
    public partial class seedlevels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7537), new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7541), new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7535) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7549), new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7551), new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7549) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7545), new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7547), new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7545) });

            migrationBuilder.InsertData(
                table: "LevelCursuses",
                columns: new[] { "Id", "ArchivedAt", "Color", "CreatedAt", "Icon", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"), new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7634), "#fa69b4", new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7636), "", "Intermediate", new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7634) },
                    { new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"), new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7637), "#ab69b4", new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7639), "", "Advanced", new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7637) },
                    { new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"), new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7629), "#ff69b4", new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7631), "", "Beginner", new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7628) }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7458));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7461));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7463));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7445));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7591), new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7593), new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7591) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7594), new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7596), new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7594) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7586), new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7588), new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7586) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"));

            migrationBuilder.DeleteData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"));

            migrationBuilder.DeleteData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 0, 3, 15, 830, DateTimeKind.Utc).AddTicks(269), new DateTime(2025, 10, 5, 0, 3, 15, 830, DateTimeKind.Utc).AddTicks(273), new DateTime(2025, 10, 5, 0, 3, 15, 830, DateTimeKind.Utc).AddTicks(267) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 0, 3, 15, 830, DateTimeKind.Utc).AddTicks(280), new DateTime(2025, 10, 5, 0, 3, 15, 830, DateTimeKind.Utc).AddTicks(282), new DateTime(2025, 10, 5, 0, 3, 15, 830, DateTimeKind.Utc).AddTicks(280) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 0, 3, 15, 830, DateTimeKind.Utc).AddTicks(277), new DateTime(2025, 10, 5, 0, 3, 15, 830, DateTimeKind.Utc).AddTicks(278), new DateTime(2025, 10, 5, 0, 3, 15, 830, DateTimeKind.Utc).AddTicks(276) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 0, 3, 15, 830, DateTimeKind.Utc).AddTicks(200));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 0, 3, 15, 830, DateTimeKind.Utc).AddTicks(203));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 0, 3, 15, 830, DateTimeKind.Utc).AddTicks(205));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 0, 3, 15, 830, DateTimeKind.Utc).AddTicks(188));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 0, 3, 15, 830, DateTimeKind.Utc).AddTicks(314), new DateTime(2025, 10, 5, 0, 3, 15, 830, DateTimeKind.Utc).AddTicks(315), new DateTime(2025, 10, 5, 0, 3, 15, 830, DateTimeKind.Utc).AddTicks(313) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 0, 3, 15, 830, DateTimeKind.Utc).AddTicks(317), new DateTime(2025, 10, 5, 0, 3, 15, 830, DateTimeKind.Utc).AddTicks(320), new DateTime(2025, 10, 5, 0, 3, 15, 830, DateTimeKind.Utc).AddTicks(317) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 0, 3, 15, 830, DateTimeKind.Utc).AddTicks(309), new DateTime(2025, 10, 5, 0, 3, 15, 830, DateTimeKind.Utc).AddTicks(311), new DateTime(2025, 10, 5, 0, 3, 15, 830, DateTimeKind.Utc).AddTicks(309) });
        }
    }
}

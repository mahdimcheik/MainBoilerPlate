using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainBoilerPlate.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 6, 20, 25, 6, 769, DateTimeKind.Utc).AddTicks(3552), null });

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 6, 20, 25, 6, 769, DateTimeKind.Utc).AddTicks(3543), null });

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 6, 20, 25, 6, 769, DateTimeKind.Utc).AddTicks(3550), null });

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 6, 20, 25, 6, 769, DateTimeKind.Utc).AddTicks(3547), null });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 6, 20, 25, 6, 769, DateTimeKind.Utc).AddTicks(3394), null });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 6, 20, 25, 6, 769, DateTimeKind.Utc).AddTicks(3402), null });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 6, 20, 25, 6, 769, DateTimeKind.Utc).AddTicks(3400), null });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 6, 20, 25, 6, 769, DateTimeKind.Utc).AddTicks(3642), null });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 6, 20, 25, 6, 769, DateTimeKind.Utc).AddTicks(3635), null });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 6, 20, 25, 6, 769, DateTimeKind.Utc).AddTicks(3639), null });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 6, 20, 25, 6, 769, DateTimeKind.Utc).AddTicks(3585), null });

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 6, 20, 25, 6, 769, DateTimeKind.Utc).AddTicks(3498), null });

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 6, 20, 25, 6, 769, DateTimeKind.Utc).AddTicks(3500), null });

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 6, 20, 25, 6, 769, DateTimeKind.Utc).AddTicks(3494), null });

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 6, 20, 25, 6, 769, DateTimeKind.Utc).AddTicks(3693), null });

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 6, 20, 25, 6, 769, DateTimeKind.Utc).AddTicks(3688), null });

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 6, 20, 25, 6, 769, DateTimeKind.Utc).AddTicks(3690), null });

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 6, 20, 25, 6, 769, DateTimeKind.Utc).AddTicks(3683), null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 20, 25, 6, 769, DateTimeKind.Utc).AddTicks(3208));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 20, 25, 6, 769, DateTimeKind.Utc).AddTicks(3216));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 20, 25, 6, 769, DateTimeKind.Utc).AddTicks(3221));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 6, 20, 25, 6, 769, DateTimeKind.Utc).AddTicks(3194));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 6, 20, 25, 6, 769, DateTimeKind.Utc).AddTicks(3453), null });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 6, 20, 25, 6, 769, DateTimeKind.Utc).AddTicks(3455), null });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 6, 20, 25, 6, 769, DateTimeKind.Utc).AddTicks(3449), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8324), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8326), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8324) });

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8314), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8315), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8313) });

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8321), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8323), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8321) });

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8318), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8320), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8318) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8169), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8172), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8168) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8179), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8181), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8179) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8176), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8178), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8175) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8367), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8369), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8367) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8361), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8363), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8361) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8364), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8366), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8364) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8356), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8358), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8356) });

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8271), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8273), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8271) });

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8274), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8276), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8274) });

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8265), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8268), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8265) });

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8412), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8413), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8412) });

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8405), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8407), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8405) });

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8408), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8410), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8408) });

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8400), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8402), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8400) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8033));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8037));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8038));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8022));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8227), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8228), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8226) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8230), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8232), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8230) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8221), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8223), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8220) });
        }
    }
}

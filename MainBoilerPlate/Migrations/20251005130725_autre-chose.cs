using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainBoilerPlate.Migrations
{
    /// <inheritdoc />
    public partial class autrechose : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserAppId",
                table: "Cursuses",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(790), new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(792), new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(789) });

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(779), new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(781), new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(778) });

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(787), new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(788), new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(786) });

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(784), new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(785), new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(783) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(554), new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(559), new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(553) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(566), new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(567), new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(565) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(562), new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(564), new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(562) });

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(748), new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(749), new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(747) });

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(751), new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(752), new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(743), new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(745), new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(743) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(468));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(471));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(474));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(458));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(702), new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(704), new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(702) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(706), new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(708), new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(706) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(696), new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(698), new DateTime(2025, 10, 5, 13, 7, 25, 453, DateTimeKind.Utc).AddTicks(695) });

            migrationBuilder.CreateIndex(
                name: "IX_Cursuses_UserAppId",
                table: "Cursuses",
                column: "UserAppId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursuses_Users_UserAppId",
                table: "Cursuses",
                column: "UserAppId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursuses_Users_UserAppId",
                table: "Cursuses");

            migrationBuilder.DropIndex(
                name: "IX_Cursuses_UserAppId",
                table: "Cursuses");

            migrationBuilder.DropColumn(
                name: "UserAppId",
                table: "Cursuses");

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6539), new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6543), new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6539) });

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6528), new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6530), new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6528) });

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6536), new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6538), new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6536) });

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6533), new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6535), new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6399), new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6404), new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6397) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6412), new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6413), new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6411) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6408), new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6410), new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6408) });

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6497), new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6498), new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6496) });

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6500), new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6502), new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6492), new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6494), new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6491) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6305));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6307));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6311));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6293));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6455), new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6457), new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6454) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6458), new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6460), new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6458) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6450), new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6452), new DateTime(2025, 10, 5, 12, 59, 34, 538, DateTimeKind.Utc).AddTicks(6450) });
        }
    }
}

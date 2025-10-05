using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainBoilerPlate.Migrations
{
    /// <inheritdoc />
    public partial class autrechose1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8832), new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8834), new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8832) });

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8820), new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8822), new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8819) });

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8827), new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8829), new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8827) });

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8824), new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8826), new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8824) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8686), new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8691), new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8684) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8700), new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8701), new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8699) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8696), new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8698), new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8696) });

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8789), new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8790), new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8789) });

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8792), new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8794), new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8792) });

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8784), new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8786), new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8783) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8550));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8589));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8592));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8537));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8745), new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8746), new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8745) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8748), new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8750), new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8748) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8741), new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8742), new DateTime(2025, 10, 5, 13, 13, 3, 535, DateTimeKind.Utc).AddTicks(8740) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}

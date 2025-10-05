using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainBoilerPlate.Migrations
{
    /// <inheritdoc />
    public partial class gendstatusmandatory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Genders_GenderId",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "GenderId",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 4, 20, 8, 56, 400, DateTimeKind.Utc).AddTicks(4685), new DateTime(2025, 10, 4, 20, 8, 56, 400, DateTimeKind.Utc).AddTicks(4690), new DateTime(2025, 10, 4, 20, 8, 56, 400, DateTimeKind.Utc).AddTicks(4684) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 4, 20, 8, 56, 400, DateTimeKind.Utc).AddTicks(4696), new DateTime(2025, 10, 4, 20, 8, 56, 400, DateTimeKind.Utc).AddTicks(4698), new DateTime(2025, 10, 4, 20, 8, 56, 400, DateTimeKind.Utc).AddTicks(4696) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 4, 20, 8, 56, 400, DateTimeKind.Utc).AddTicks(4693), new DateTime(2025, 10, 4, 20, 8, 56, 400, DateTimeKind.Utc).AddTicks(4695), new DateTime(2025, 10, 4, 20, 8, 56, 400, DateTimeKind.Utc).AddTicks(4693) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 4, 20, 8, 56, 400, DateTimeKind.Utc).AddTicks(4609));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 4, 20, 8, 56, 400, DateTimeKind.Utc).AddTicks(4612));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 4, 20, 8, 56, 400, DateTimeKind.Utc).AddTicks(4615));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 4, 20, 8, 56, 400, DateTimeKind.Utc).AddTicks(4598));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 4, 20, 8, 56, 400, DateTimeKind.Utc).AddTicks(4733), new DateTime(2025, 10, 4, 20, 8, 56, 400, DateTimeKind.Utc).AddTicks(4734), new DateTime(2025, 10, 4, 20, 8, 56, 400, DateTimeKind.Utc).AddTicks(4732) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 4, 20, 8, 56, 400, DateTimeKind.Utc).AddTicks(4736), new DateTime(2025, 10, 4, 20, 8, 56, 400, DateTimeKind.Utc).AddTicks(4738), new DateTime(2025, 10, 4, 20, 8, 56, 400, DateTimeKind.Utc).AddTicks(4735) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 4, 20, 8, 56, 400, DateTimeKind.Utc).AddTicks(4728), new DateTime(2025, 10, 4, 20, 8, 56, 400, DateTimeKind.Utc).AddTicks(4729), new DateTime(2025, 10, 4, 20, 8, 56, 400, DateTimeKind.Utc).AddTicks(4727) });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Genders_GenderId",
                table: "Users",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Genders_GenderId",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "GenderId",
                table: "Users",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Genders_GenderId",
                table: "Users",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id");
        }
    }
}

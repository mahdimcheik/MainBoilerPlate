using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainBoilerPlate.Migrations
{
    /// <inheritdoc />
    public partial class colrcolor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_Roles_RoleAppId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_Users_UserAppId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_RoleAppId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserAppId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "RoleAppId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "UserAppId",
                table: "AspNetUserRoles");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Roles",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7332));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7338));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7336));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7217));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7224));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7222));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7444));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7438));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7440));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7434));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7300));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7303));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7297));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7476));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7471));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7474));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7468));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "Color", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7126) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "Color", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7132) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                columns: new[] { "Color", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7135) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "Color", "CreatedAt" },
                values: new object[] { null, new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7114) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7263));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7266));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7260));

            migrationBuilder.UpdateData(
                table: "TypeSlots",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7509));

            migrationBuilder.UpdateData(
                table: "TypeSlots",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 10, 12, 42, 796, DateTimeKind.Utc).AddTicks(7506));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Roles");

            migrationBuilder.AddColumn<Guid>(
                name: "RoleAppId",
                table: "AspNetUserRoles",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserAppId",
                table: "AspNetUserRoles",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9560));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9549));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9554));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9552));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9405));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9412));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9409));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9611));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9606));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9608));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9602));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9509));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9512));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9506));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9655));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9650));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9652));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9647));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9252));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9255));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9257));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9238));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9465));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9468));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9461));

            migrationBuilder.UpdateData(
                table: "TypeSlots",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9697));

            migrationBuilder.UpdateData(
                table: "TypeSlots",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 14, 36, 17, 855, DateTimeKind.Utc).AddTicks(9693));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleAppId",
                table: "AspNetUserRoles",
                column: "RoleAppId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserAppId",
                table: "AspNetUserRoles",
                column: "UserAppId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Roles_RoleAppId",
                table: "AspNetUserRoles",
                column: "RoleAppId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Users_UserAppId",
                table: "AspNetUserRoles",
                column: "UserAppId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

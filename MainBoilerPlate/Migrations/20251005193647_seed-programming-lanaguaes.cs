using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MainBoilerPlate.Migrations
{
    /// <inheritdoc />
    public partial class seedprogramminglanaguaes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Languages",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Languages",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Languages",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Languages",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Formations",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Institution",
                table: "Formations",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Formations",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Formations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Experiences",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Institution",
                table: "Experiences",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Experiences",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Experiences",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateTable(
                name: "ProgrammingLanguages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ArchivedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Color = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Icon = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersXProgrammingLanguages",
                columns: table => new
                {
                    ProgrammingLanguageId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersXProgrammingLanguages", x => new { x.ProgrammingLanguageId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UsersXProgrammingLanguages_ProgrammingLanguages_UserId",
                        column: x => x.UserId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersXProgrammingLanguages_Users_ProgrammingLanguageId",
                        column: x => x.ProgrammingLanguageId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "ArchivedAt", "Color", "CreatedAt", "Description", "Icon", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8412), "#ab69b4", new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8413), null, "", "C++", new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8412) },
                    { new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8405), "#fa69b4", new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8407), null, "", "Java", new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8405) },
                    { new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8408), "#ab69b4", new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8410), null, "", "C#", new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8408) },
                    { new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"), new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8400), "#ff69b4", new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8402), null, "", "JavaScript", new DateTime(2025, 10, 5, 19, 36, 46, 701, DateTimeKind.Utc).AddTicks(8400) }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UsersXProgrammingLanguages_UserId",
                table: "UsersXProgrammingLanguages",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersXProgrammingLanguages");

            migrationBuilder.DropTable(
                name: "ProgrammingLanguages");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Languages",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Languages",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Languages",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Languages",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Formations",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Institution",
                table: "Formations",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Formations",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Formations",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Experiences",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Institution",
                table: "Experiences",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Experiences",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Experiences",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5848), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5849), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5847) });

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5836), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5838), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5835) });

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5844), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5846), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5844) });

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5841), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5842), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5840) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5716), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5720), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5712) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5727), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5729), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5727) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5723), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5725), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5723) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5931), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5933), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5931) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5880), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5882), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5880) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5883), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5885), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5883) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5876), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5878), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5876) });

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5806), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5808), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5806) });

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5809), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5811), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5809) });

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5802), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5804), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5801) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5634));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5639));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5641));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5624));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5768), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5770), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5768) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5772), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5773), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5771) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5763), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5765), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5763) });
        }
    }
}

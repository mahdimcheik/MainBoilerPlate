using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MainBoilerPlate.Migrations
{
    /// <inheritdoc />
    public partial class addcategoryseedcategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryCursuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ArchivedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Color = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    Icon = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryCursuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategorieCursus",
                columns: table => new
                {
                    CategorieId = table.Column<Guid>(type: "uuid", nullable: false),
                    CursusId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieCursus", x => new { x.CategorieId, x.CursusId });
                    table.ForeignKey(
                        name: "FK_CategorieCursus_CategoryCursuses_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "CategoryCursuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategorieCursus_Cursuses_CursusId",
                        column: x => x.CursusId,
                        principalTable: "Cursuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CategoryCursuses",
                columns: new[] { "Id", "ArchivedAt", "Color", "CreatedAt", "Icon", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4634), "#ab69b4", new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4636), "", "Back-end", new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4634) },
                    { new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4623), "#ff69b4", new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4624), "", "Soft skills", new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4622) },
                    { new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4631), "#ab69b4", new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4633), "", "Front-end", new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4631) },
                    { new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4627), "#fa69b4", new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4629), "", "Technics", new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4627) }
                });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4504), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4508), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4503) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4515), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4516), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4514) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4511), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4513), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4511) });

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4592), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4594), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4592) });

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4595), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4597), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4595) });

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4588), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4590), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4587) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4421));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4424));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4427));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4409));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4552), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4553), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4551) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4555), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4556), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4555) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4547), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4548), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4546) });

            migrationBuilder.CreateIndex(
                name: "IX_CategorieCursus_CursusId",
                table: "CategorieCursus",
                column: "CursusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorieCursus");

            migrationBuilder.DropTable(
                name: "CategoryCursuses");

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

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7634), new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7636), new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7634) });

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7637), new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7639), new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7637) });

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7629), new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7631), new DateTime(2025, 10, 5, 0, 11, 39, 256, DateTimeKind.Utc).AddTicks(7628) });

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
    }
}

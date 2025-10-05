using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainBoilerPlate.Migrations
{
    /// <inheritdoc />
    public partial class renamejointure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorieCursus");

            migrationBuilder.CreateTable(
                name: "CursusCategories",
                columns: table => new
                {
                    CategorieId = table.Column<Guid>(type: "uuid", nullable: false),
                    CursusId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursusCategories", x => new { x.CategorieId, x.CursusId });
                    table.ForeignKey(
                        name: "FK_CursusCategories_CategoryCursuses_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "CategoryCursuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CursusCategories_Cursuses_CursusId",
                        column: x => x.CursusId,
                        principalTable: "Cursuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(5071), new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(5074), new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(5070) });

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(5058), new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(5060), new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(5057) });

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(5068), new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(5069), new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(5067) });

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(5063), new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(5065), new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(5062) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(4918), new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(4922), new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(4917) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(4930), new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(4931), new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(4929) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(4926), new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(4928), new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(4926) });

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(5020), new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(5022), new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(5020) });

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(5023), new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(5025), new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(5023) });

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(5015), new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(5017), new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(5015) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(4790));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(4793));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(4795));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(4775));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(4977), new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(4978), new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(4976) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(4980), new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(4981), new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(4979) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(4971), new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(4973), new DateTime(2025, 10, 5, 7, 26, 40, 799, DateTimeKind.Utc).AddTicks(4971) });

            migrationBuilder.CreateIndex(
                name: "IX_CursusCategories_CursusId",
                table: "CursusCategories",
                column: "CursusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursusCategories");

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

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4634), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4636), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4634) });

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4623), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4624), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4622) });

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4631), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4633), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4631) });

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4627), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4629), new DateTime(2025, 10, 5, 7, 23, 32, 868, DateTimeKind.Utc).AddTicks(4627) });

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
    }
}

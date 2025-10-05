using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainBoilerPlate.Migrations
{
    /// <inheritdoc />
    public partial class addlanguageswithrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formation_Users_UserId",
                table: "Formation");

            migrationBuilder.DropTable(
                name: "CursusCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Formation",
                table: "Formation");

            migrationBuilder.RenameTable(
                name: "Formation",
                newName: "Formations");

            migrationBuilder.RenameIndex(
                name: "IX_Formation_UserId",
                table: "Formations",
                newName: "IX_Formations_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Formations",
                table: "Formations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CursusXCategories",
                columns: table => new
                {
                    CategorieId = table.Column<Guid>(type: "uuid", nullable: false),
                    CursusId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursusXCategories", x => new { x.CategorieId, x.CursusId });
                    table.ForeignKey(
                        name: "FK_CursusXCategories_CategoryCursuses_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "CategoryCursuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CursusXCategories_Cursuses_CursusId",
                        column: x => x.CursusId,
                        principalTable: "Cursuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Institution = table.Column<string>(type: "text", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ArchivedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ArchivedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersXLanguages",
                columns: table => new
                {
                    LanguageId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersXLanguages", x => new { x.LanguageId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UsersXLanguages_Languages_UserId",
                        column: x => x.UserId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersXLanguages_Users_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CursusXCategories_CursusId",
                table: "CursusXCategories",
                column: "CursusId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_UserId",
                table: "Experiences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersXLanguages_UserId",
                table: "UsersXLanguages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Formations_Users_UserId",
                table: "Formations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formations_Users_UserId",
                table: "Formations");

            migrationBuilder.DropTable(
                name: "CursusXCategories");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "UsersXLanguages");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Formations",
                table: "Formations");

            migrationBuilder.RenameTable(
                name: "Formations",
                newName: "Formation");

            migrationBuilder.RenameIndex(
                name: "IX_Formations_UserId",
                table: "Formation",
                newName: "IX_Formation_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Formation",
                table: "Formation",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Formation_Users_UserId",
                table: "Formation",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

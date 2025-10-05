using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainBoilerPlate.Migrations
{
    /// <inheritdoc />
    public partial class cursuslevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Formation",
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
                    table.PrimaryKey("PK_Formation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Formation_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LevelCursuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", maxLength: 64, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ArchivedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Color = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    Icon = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelCursuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    ImgUrl = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    LevelId = table.Column<Guid>(type: "uuid", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ArchivedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Color = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    Icon = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cursuses_LevelCursuses_LevelId",
                        column: x => x.LevelId,
                        principalTable: "LevelCursuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cursuses_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Cursuses_LevelId",
                table: "Cursuses",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cursuses_TeacherId",
                table: "Cursuses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Formation_UserId",
                table: "Formation",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursuses");

            migrationBuilder.DropTable(
                name: "Formation");

            migrationBuilder.DropTable(
                name: "LevelCursuses");

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 4, 20, 14, 51, 600, DateTimeKind.Utc).AddTicks(4590), new DateTime(2025, 10, 4, 20, 14, 51, 600, DateTimeKind.Utc).AddTicks(4594), new DateTime(2025, 10, 4, 20, 14, 51, 600, DateTimeKind.Utc).AddTicks(4589) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 4, 20, 14, 51, 600, DateTimeKind.Utc).AddTicks(4601), new DateTime(2025, 10, 4, 20, 14, 51, 600, DateTimeKind.Utc).AddTicks(4605), new DateTime(2025, 10, 4, 20, 14, 51, 600, DateTimeKind.Utc).AddTicks(4601) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 4, 20, 14, 51, 600, DateTimeKind.Utc).AddTicks(4598), new DateTime(2025, 10, 4, 20, 14, 51, 600, DateTimeKind.Utc).AddTicks(4599), new DateTime(2025, 10, 4, 20, 14, 51, 600, DateTimeKind.Utc).AddTicks(4597) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 4, 20, 14, 51, 600, DateTimeKind.Utc).AddTicks(4511));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 4, 20, 14, 51, 600, DateTimeKind.Utc).AddTicks(4513));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 4, 20, 14, 51, 600, DateTimeKind.Utc).AddTicks(4516));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 4, 20, 14, 51, 600, DateTimeKind.Utc).AddTicks(4496));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 4, 20, 14, 51, 600, DateTimeKind.Utc).AddTicks(4691), new DateTime(2025, 10, 4, 20, 14, 51, 600, DateTimeKind.Utc).AddTicks(4693), new DateTime(2025, 10, 4, 20, 14, 51, 600, DateTimeKind.Utc).AddTicks(4691) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 4, 20, 14, 51, 600, DateTimeKind.Utc).AddTicks(4695), new DateTime(2025, 10, 4, 20, 14, 51, 600, DateTimeKind.Utc).AddTicks(4697), new DateTime(2025, 10, 4, 20, 14, 51, 600, DateTimeKind.Utc).AddTicks(4694) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "ArchivedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 4, 20, 14, 51, 600, DateTimeKind.Utc).AddTicks(4686), new DateTime(2025, 10, 4, 20, 14, 51, 600, DateTimeKind.Utc).AddTicks(4688), new DateTime(2025, 10, 4, 20, 14, 51, 600, DateTimeKind.Utc).AddTicks(4685) });
        }
    }
}

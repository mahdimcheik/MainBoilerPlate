using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MainBoilerPlate.Migrations
{
    /// <inheritdoc />
    public partial class seedlanguages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "ArchivedAt", "Color", "CreatedAt", "Icon", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5931), "#ab69b4", new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5933), "", "Spanich", new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5931) },
                    { new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5880), "#fa69b4", new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5882), "", "English", new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5880) },
                    { new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5883), "#ab69b4", new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5885), "", "Arab", new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5883) },
                    { new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"), new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5876), "#ff69b4", new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5878), "", "French", new DateTime(2025, 10, 5, 13, 20, 53, 542, DateTimeKind.Utc).AddTicks(5876) }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"));

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
    }
}

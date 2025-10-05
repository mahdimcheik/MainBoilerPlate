using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainBoilerPlate.Migrations
{
    /// <inheritdoc />
    public partial class gendstatusmandarywithdefaultvalues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobMS.Migrations
{
    /// <inheritdoc />
    public partial class updates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cbf0e259-b8f9-4bc8-b1af-87d7227dad33", new DateTime(2026, 4, 18, 22, 15, 44, 871, DateTimeKind.Local).AddTicks(7717), "AQAAAAIAAYagAAAAEFpLUnXmFzCCFzkvR5DMkKwOmRrY5xvPU2+0BvVi8+rSM5ib9QL3hMkhMnySRWNB7A==", "1ba2e3f5-e3a7-4a88-95c3-982b3d182f3b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16c8b26d-f107-47e4-bf01-99132879c7f0", new DateTime(2026, 4, 18, 22, 15, 44, 923, DateTimeKind.Local).AddTicks(845), "AQAAAAIAAYagAAAAEFKp2ePqJtiWAMOd5HbdE+LbztYaspU5g0o8Zni1oeWSIA2D4RlxCTfgSkyzt1dmNg==", "f76345ab-3aeb-4edf-8202-9f1fd43ac002" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af3d2fdb-eca5-44f6-8a3a-e93a905adb65", new DateTime(2026, 4, 18, 22, 15, 44, 970, DateTimeKind.Local).AddTicks(4373), "AQAAAAIAAYagAAAAEHrm4H2XkOXcWoedGvqd40Z0CupXOrfYETAdKF7i8VxiJakMMQfrJEyFLSv2vqakyw==", "b4438468-c72f-435a-a049-d27c95ab81da" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba1d1d6b-2400-446f-b6b3-f21670f4b9f5", new DateTime(2026, 4, 18, 20, 42, 27, 502, DateTimeKind.Local).AddTicks(5666), "AQAAAAIAAYagAAAAEEALVSxzlx7bmuk+kGdYszfHrTLgi7d1HIFXObWr1XeC2s4Il/mwdw0kj+B3v1bkMQ==", "238974d4-caf5-43fe-8feb-879317780685" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ff26379-989b-498d-98b3-2d5a299420ac", new DateTime(2026, 4, 18, 20, 42, 27, 552, DateTimeKind.Local).AddTicks(7030), "AQAAAAIAAYagAAAAEGwpapTUW1E3+szbXJS5hZI8R3aIHwO/7R3oDz2nOwnDVbZu+kMzf0V+6L60X/uJYA==", "d0afe315-f37f-4bf0-aa7b-ebcaf5266ef9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b6379a6-dabf-4d6b-8dc2-5c33584b6396", new DateTime(2026, 4, 18, 20, 42, 27, 599, DateTimeKind.Local).AddTicks(3529), "AQAAAAIAAYagAAAAEI3YhqapzPYgSBARY8NjhJolYdE5DR9E8DP6ld9nV9XsiDAqqGTbIoh1rnMpiG62RQ==", "81564895-8c9c-4a33-b283-c43e312cedee" });
        }
    }
}

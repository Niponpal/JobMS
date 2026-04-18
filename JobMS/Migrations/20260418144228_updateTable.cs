using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobMS.Migrations
{
    /// <inheritdoc />
    public partial class updateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7043c29-57dd-4e1f-985d-d4223298c90c", new DateTime(2026, 4, 18, 13, 53, 44, 423, DateTimeKind.Local).AddTicks(183), "AQAAAAIAAYagAAAAEOtAi6xqajGiFbeJsaODQs8LhqpN+Wdp8ecBisC+vlA3UCT+BLGz6SpxFJsNByX/vA==", "42875ef8-b475-4133-8fc7-ca4b50323bbf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "827e84a2-5297-4373-9a63-37e4ef4a2a08", new DateTime(2026, 4, 18, 13, 53, 44, 475, DateTimeKind.Local).AddTicks(7399), "AQAAAAIAAYagAAAAENU+/qInRRIvzhnDHFqA3YuhVrruDWkW7FMCXX7FwmkEZ81Hpk3ksVrCRK4s74Q0eA==", "24618b6b-a426-42f6-a3f0-4c9799f85e07" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "599debcc-0295-4c8c-844c-6bcbd387169b", new DateTime(2026, 4, 18, 13, 53, 44, 523, DateTimeKind.Local).AddTicks(4200), "AQAAAAIAAYagAAAAEBQCxUkSuS8mqblmMCIadZr7jbdiv5IsEtQV0Klkyp0h2ysrF7biWPY8cc+5Z+0ylA==", "020f785c-387b-4b58-91dc-cb0e58b3c3ae" });
        }
    }
}

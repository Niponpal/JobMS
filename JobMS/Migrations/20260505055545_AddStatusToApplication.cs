using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobMS.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusToApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4080ab74-2d5e-4c2e-90b3-6dcbd0f085dd", new DateTime(2026, 5, 5, 11, 55, 45, 191, DateTimeKind.Local).AddTicks(9684), "AQAAAAIAAYagAAAAEAhGoqHgm0IdZ+ifTlXYNnX+mqR1zZgdPqj344Ph/lNI7TUKduZaNi1TG+3DJBCFPA==", "c33a8b44-f339-4268-acd6-d8ef2d930f15" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8efe0930-514c-49f5-bfd7-18f2bd15656a", new DateTime(2026, 5, 5, 11, 55, 45, 242, DateTimeKind.Local).AddTicks(3199), "AQAAAAIAAYagAAAAEMVOR9J7rpmyMs0xKTszQ7Uq84nq81rClvlBbRaZzWN9Rf+gOLI0mBHDQktsWYBE3w==", "91c5b07c-3a02-4b82-8f29-fc3f7f74b09b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc057c21-0970-43cb-9927-5100006fe5ad", new DateTime(2026, 5, 5, 11, 55, 45, 288, DateTimeKind.Local).AddTicks(7454), "AQAAAAIAAYagAAAAEBe1RiyezSUqmgYFfj4vM1rsekdCIGqPOi/LR0kAT38aQwBOf+5TRovkUUneI3c90Q==", "94bff288-43d8-4fe9-a57a-a30998f4a146" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Applications");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9aeffeb5-658e-4862-8a91-93cc62ef47db", new DateTime(2026, 4, 30, 11, 55, 34, 900, DateTimeKind.Local).AddTicks(8050), "AQAAAAIAAYagAAAAEDTULhE/5iDr8icVsvEd6tHToVqM5IoZvgv83UEA4yq3KiOo+Sa4S/XU8XUPH+yemQ==", "c5a9b5d8-2b26-435d-9d75-9166aca5853f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36d2e3a1-ad7d-42c5-85d6-0cd662f288d9", new DateTime(2026, 4, 30, 11, 55, 34, 950, DateTimeKind.Local).AddTicks(5592), "AQAAAAIAAYagAAAAEOHdLX6hDV9uM1FKitjZ/O6+DOVpFUwfqR67eKA/nEx2IXkkYq0spi/shw9CdIXFKA==", "3ade6930-7d30-4627-b95e-f363b57def0d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2edb1164-8e5f-4f29-858a-21ab912c06bb", new DateTime(2026, 4, 30, 11, 55, 34, 996, DateTimeKind.Local).AddTicks(9541), "AQAAAAIAAYagAAAAEKjwwdxc+ACLfYRtmtv5v0ESQmYf6s7HI9IA76+xOcbaSbIQXMxnsJTNoVU50XlEsA==", "ea156196-6c8a-4852-8671-27e09c584adc" });
        }
    }
}

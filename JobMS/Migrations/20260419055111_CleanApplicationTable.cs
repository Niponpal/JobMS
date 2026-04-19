using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobMS.Migrations
{
    /// <inheritdoc />
    public partial class CleanApplicationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_AspNetUsers_UserId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_UserId",
                table: "Applications");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "Applications",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09703056-b617-40a7-8678-7c3bef83d754", new DateTime(2026, 4, 19, 11, 51, 10, 674, DateTimeKind.Local).AddTicks(8229), "AQAAAAIAAYagAAAAEIbYcESeOgAl8jqpido/3pqruk4lDeBb4KMnqq/jjC4Hd9fwWejqFWBGn7vpo6O/mg==", "4d1c48d1-9c69-4a45-91bb-db5cc215985a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6107bd1-84c1-441c-8ca3-9de0e0de506c", new DateTime(2026, 4, 19, 11, 51, 10, 724, DateTimeKind.Local).AddTicks(6184), "AQAAAAIAAYagAAAAEEIprUe03vFY/3sfbTo4z7nfxLjXsj6vkdwm3RrFzXVgIoyfL7lvGw4b+0v28KyLWw==", "6605260a-1b28-4b73-a539-ea29e3043d2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6c924d0-3bac-4eb3-9f4f-af16e63e3f74", new DateTime(2026, 4, 19, 11, 51, 10, 771, DateTimeKind.Local).AddTicks(8064), "AQAAAAIAAYagAAAAEHSGkvAcZEHjyOmR4xqYtrB7yYArYmKz+Fp+9DaPdv/S2PCrMKjTfYKvDEPekoLwNw==", "8de5d9cf-e8e2-409d-856b-8f1a734ea1f9" });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserId1",
                table: "Applications",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_AspNetUsers_UserId1",
                table: "Applications",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_AspNetUsers_UserId1",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_UserId1",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Applications");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Applications",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserId",
                table: "Applications",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_AspNetUsers_UserId",
                table: "Applications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

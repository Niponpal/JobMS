using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobMS.Migrations
{
    /// <inheritdoc />
    public partial class CleanApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_AspNetUsers_UserId1",
                table: "Applications");

            migrationBuilder.AlterColumn<long>(
                name: "UserId1",
                table: "Applications",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

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
                values: new object[] { "95885818-af62-42fe-8321-40d26fa92e28", new DateTime(2026, 4, 19, 11, 58, 13, 528, DateTimeKind.Local).AddTicks(4287), "AQAAAAIAAYagAAAAEIK70Y6te5/ZjSZcjtlx4T9BbU8ZpRhML665/+BsmFXN/KiI1iE5q+xMCV/rkg+qTg==", "5d84b3ae-d963-464c-a7f8-f080d6a86195" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9bd5b384-e300-44a5-bbd9-2fbdb5ca1e7a", new DateTime(2026, 4, 19, 11, 58, 13, 579, DateTimeKind.Local).AddTicks(279), "AQAAAAIAAYagAAAAEFP1PavvLNG8x2b7RdmEZQF1j4bWP8mIAi1ox/TS+P+8/sxbWa8FB8+Fx8fzf7PmXw==", "6f7902a0-38b7-4e3e-be48-cf0e4f3e905f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25964ba4-3d43-46a6-8307-f5148f33be03", new DateTime(2026, 4, 19, 11, 58, 13, 626, DateTimeKind.Local).AddTicks(4851), "AQAAAAIAAYagAAAAEIw8UStABIwvU9FxOiznvV37e1M36weVGd2GiwW6kv7HTNtHP8vy6eZVDsa2XXsJNQ==", "66f9f8f6-388b-429c-aa8f-d3f5a4ceeb1c" });

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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_AspNetUsers_UserId1",
                table: "Applications",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_AspNetUsers_UserId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_AspNetUsers_UserId1",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_UserId",
                table: "Applications");

            migrationBuilder.AlterColumn<long>(
                name: "UserId1",
                table: "Applications",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_AspNetUsers_UserId1",
                table: "Applications",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

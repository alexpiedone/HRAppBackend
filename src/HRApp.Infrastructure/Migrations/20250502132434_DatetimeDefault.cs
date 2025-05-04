using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DatetimeDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 16, 24, 34, 351, DateTimeKind.Local).AddTicks(8771));

            migrationBuilder.UpdateData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 16, 24, 34, 355, DateTimeKind.Local).AddTicks(8281));

            migrationBuilder.UpdateData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 16, 24, 34, 355, DateTimeKind.Local).AddTicks(9199));

            migrationBuilder.UpdateData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 16, 24, 34, 355, DateTimeKind.Local).AddTicks(9221));

            migrationBuilder.UpdateData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 16, 24, 34, 355, DateTimeKind.Local).AddTicks(9224));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 16, 24, 34, 355, DateTimeKind.Local).AddTicks(4218));

            migrationBuilder.CreateIndex(
                name: "IX_NewsItems_AuthorId",
                table: "NewsItems",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsItems_Users_AuthorId",
                table: "NewsItems",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsItems_Users_AuthorId",
                table: "NewsItems");

            migrationBuilder.DropIndex(
                name: "IX_NewsItems_AuthorId",
                table: "NewsItems");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 15, 43, 52, 67, DateTimeKind.Local).AddTicks(6166));

            migrationBuilder.UpdateData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 15, 43, 52, 94, DateTimeKind.Local).AddTicks(1397));

            migrationBuilder.UpdateData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 15, 43, 52, 94, DateTimeKind.Local).AddTicks(1768));

            migrationBuilder.UpdateData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 15, 43, 52, 94, DateTimeKind.Local).AddTicks(1778));

            migrationBuilder.UpdateData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 15, 43, 52, 94, DateTimeKind.Local).AddTicks(1780));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 15, 43, 52, 93, DateTimeKind.Local).AddTicks(8391));
        }
    }
}

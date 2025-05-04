using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class futemasINMMDEMIGRARI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "NewsItems",
                newName: "CategoryId");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 17, 12, 33, 301, DateTimeKind.Local).AddTicks(4084));

            migrationBuilder.UpdateData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 17, 12, 33, 304, DateTimeKind.Local).AddTicks(8335));

            migrationBuilder.UpdateData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 17, 12, 33, 304, DateTimeKind.Local).AddTicks(8719));

            migrationBuilder.UpdateData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 17, 12, 33, 304, DateTimeKind.Local).AddTicks(8731));

            migrationBuilder.UpdateData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 17, 12, 33, 304, DateTimeKind.Local).AddTicks(8733));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 17, 12, 33, 304, DateTimeKind.Local).AddTicks(5293));

            migrationBuilder.CreateIndex(
                name: "IX_NewsItems_CategoryId",
                table: "NewsItems",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsItems_NewsCategories_CategoryId",
                table: "NewsItems",
                column: "CategoryId",
                principalTable: "NewsCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsItems_NewsCategories_CategoryId",
                table: "NewsItems");

            migrationBuilder.DropIndex(
                name: "IX_NewsItems_CategoryId",
                table: "NewsItems");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "NewsItems",
                newName: "Category");

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
        }
    }
}

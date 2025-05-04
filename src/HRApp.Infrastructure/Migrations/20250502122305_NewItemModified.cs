using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewItemModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskStatus",
                table: "Tasks",
                newName: "Status");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "NewsItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "NewsItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isPrincipal",
                table: "NewsItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 15, 23, 3, 254, DateTimeKind.Local).AddTicks(8422));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 15, 23, 3, 258, DateTimeKind.Local).AddTicks(4184));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "NewsItems");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "NewsItems");

            migrationBuilder.DropColumn(
                name: "isPrincipal",
                table: "NewsItems");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Tasks",
                newName: "TaskStatus");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 9, 16, 25, 802, DateTimeKind.Local).AddTicks(6015));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 9, 16, 25, 806, DateTimeKind.Local).AddTicks(2124));
        }
    }
}

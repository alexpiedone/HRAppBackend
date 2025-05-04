using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TaskAction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskActions",
                table: "TaskActions");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TaskActions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "TaskActions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TaskActions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskActions",
                table: "TaskActions",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 9, 37, 59, 876, DateTimeKind.Local).AddTicks(704));

            migrationBuilder.UpdateData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 9, 37, 59, 880, DateTimeKind.Local).AddTicks(772));

            migrationBuilder.UpdateData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 9, 37, 59, 880, DateTimeKind.Local).AddTicks(1280));

            migrationBuilder.UpdateData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 9, 37, 59, 880, DateTimeKind.Local).AddTicks(1295));

            migrationBuilder.UpdateData(
                table: "NewsCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 9, 37, 59, 880, DateTimeKind.Local).AddTicks(1298));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 9, 37, 59, 879, DateTimeKind.Local).AddTicks(6448));

            migrationBuilder.CreateIndex(
                name: "IX_TaskActions_TaskId",
                table: "TaskActions",
                column: "TaskId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskActions",
                table: "TaskActions");

            migrationBuilder.DropIndex(
                name: "IX_TaskActions_TaskId",
                table: "TaskActions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TaskActions");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "TaskActions");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TaskActions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskActions",
                table: "TaskActions",
                column: "TaskId");

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
        }
    }
}

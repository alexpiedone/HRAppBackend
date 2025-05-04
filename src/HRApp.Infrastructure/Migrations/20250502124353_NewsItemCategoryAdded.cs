using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewsItemCategoryAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCategories", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 15, 43, 52, 67, DateTimeKind.Local).AddTicks(6166));

            migrationBuilder.InsertData(
                table: "NewsCategories",
                columns: new[] { "Id", "Active", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2025, 5, 2, 15, 43, 52, 94, DateTimeKind.Local).AddTicks(1397), "Announcement" },
                    { 2, true, new DateTime(2025, 5, 2, 15, 43, 52, 94, DateTimeKind.Local).AddTicks(1768), "Update" },
                    { 3, true, new DateTime(2025, 5, 2, 15, 43, 52, 94, DateTimeKind.Local).AddTicks(1778), "Event" },
                    { 4, true, new DateTime(2025, 5, 2, 15, 43, 52, 94, DateTimeKind.Local).AddTicks(1780), "General" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 15, 43, 52, 93, DateTimeKind.Local).AddTicks(8391));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsCategories");

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
    }
}

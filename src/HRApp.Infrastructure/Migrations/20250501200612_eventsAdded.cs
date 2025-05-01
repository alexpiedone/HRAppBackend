using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class eventsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Active", "Address", "CreatedAt", "Email", "Name", "PhoneNumber" },
                values: new object[] { 1, true, "", new DateTime(2025, 5, 1, 23, 6, 11, 126, DateTimeKind.Local).AddTicks(6408), "helpiehr@contact.ro", "Helpie", "0430-571-555" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 23, 6, 11, 129, DateTimeKind.Local).AddTicks(3080));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 30, 18, 36, 38, 448, DateTimeKind.Local).AddTicks(5474));
        }
    }
}

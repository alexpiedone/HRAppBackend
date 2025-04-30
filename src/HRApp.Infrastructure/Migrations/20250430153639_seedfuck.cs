using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedfuck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "AvatarFileId", "CompanyId", "CreatedAt", "Email", "FullName", "PasswordHash", "Phone", "TrainingId", "Username" },
                values: new object[] { 1, true, null, 1, new DateTime(2025, 4, 30, 18, 36, 38, 448, DateTimeKind.Local).AddTicks(5474), "test", "", "", "", null, "Shadow" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

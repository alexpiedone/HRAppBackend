using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AutoMigration_23243242 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AnotherBoolean",
                table: "Training",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnotherBoolean",
                table: "Training");
        }
    }
}

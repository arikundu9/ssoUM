using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ssoUM.Migrations
{
    /// <inheritdoc />
    public partial class AppNameAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "app_name",
                table: "app",
                type: "character(30)",
                fixedLength: true,
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "app_name",
                table: "app");
        }
    }
}

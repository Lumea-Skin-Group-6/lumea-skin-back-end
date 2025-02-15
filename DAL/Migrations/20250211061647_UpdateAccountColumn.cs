using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAccountColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "accounts");

            migrationBuilder.AddColumn<bool>(
                name: "is_logged_in",
                table: "accounts",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_logged_in",
                table: "accounts");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "accounts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}

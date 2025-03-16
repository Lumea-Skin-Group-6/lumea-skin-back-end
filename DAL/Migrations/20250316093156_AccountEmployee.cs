using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AccountEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_employees_account_id",
                table: "employees");

            migrationBuilder.CreateIndex(
                name: "IX_employees_account_id",
                table: "employees",
                column: "account_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_employees_account_id",
                table: "employees");

            migrationBuilder.CreateIndex(
                name: "IX_employees_account_id",
                table: "employees",
                column: "account_id");
        }
    }
}

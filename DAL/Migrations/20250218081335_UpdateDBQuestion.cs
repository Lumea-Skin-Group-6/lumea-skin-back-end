using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDBQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "questions",
            columns: table => new
            {
                id = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                question_content = table.Column<string>(nullable: false),
                service_type = table.Column<int>(nullable: false),
                is_multiple_choice = table.Column<bool>(nullable: false),
                updated_at = table.Column<DateTime>(nullable: false),
                display_order = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_questions", x => x.id);
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "questions");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixEmployeeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_answer_questions_question_id",
                table: "answer");

            migrationBuilder.AddColumn<int>(
                name: "questionId",
                table: "answer",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_answer_questionId",
                table: "answer",
                column: "questionId");

            migrationBuilder.AddForeignKey(
                name: "FK_answer_questions_questionId",
                table: "answer",
                column: "questionId",
                principalTable: "questions",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_answer_questions_questionId",
                table: "answer");

            migrationBuilder.DropIndex(
                name: "IX_answer_questionId",
                table: "answer");

            migrationBuilder.DropColumn(
                name: "questionId",
                table: "answer");

            migrationBuilder.AddForeignKey(
                name: "FK_answer_questions_question_id",
                table: "answer",
                column: "question_id",
                principalTable: "questions",
                principalColumn: "id");
        }
    }
}

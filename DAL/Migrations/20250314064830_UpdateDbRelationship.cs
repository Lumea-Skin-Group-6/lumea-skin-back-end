using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "questions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_therapist_shift_shift_id",
                table: "therapist_shift",
                column: "shift_id");

            migrationBuilder.CreateIndex(
                name: "IX_therapist_shift_therapist_id",
                table: "therapist_shift",
                column: "therapist_id");

            migrationBuilder.CreateIndex(
                name: "IX_answer_question_id",
                table: "answer",
                column: "question_id");

            migrationBuilder.AddForeignKey(
                name: "FK_answer_questions_question_id",
                table: "answer",
                column: "question_id",
                principalTable: "questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_therapist_shift_employees_therapist_id",
                table: "therapist_shift",
                column: "therapist_id",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_therapist_shift_shifts_shift_id",
                table: "therapist_shift",
                column: "shift_id",
                principalTable: "shifts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_answer_questions_question_id",
                table: "answer");

            migrationBuilder.DropForeignKey(
                name: "FK_therapist_shift_employees_therapist_id",
                table: "therapist_shift");

            migrationBuilder.DropForeignKey(
                name: "FK_therapist_shift_shifts_shift_id",
                table: "therapist_shift");

            migrationBuilder.DropIndex(
                name: "IX_therapist_shift_shift_id",
                table: "therapist_shift");

            migrationBuilder.DropIndex(
                name: "IX_therapist_shift_therapist_id",
                table: "therapist_shift");

            migrationBuilder.DropIndex(
                name: "IX_answer_question_id",
                table: "answer");

            migrationBuilder.DropColumn(
                name: "status",
                table: "questions");

            migrationBuilder.AddColumn<int>(
                name: "shiftId",
                table: "therapist_shift",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "therapistId",
                table: "therapist_shift",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "display_order",
                table: "questions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "service_type",
                table: "questions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "questionId",
                table: "answer",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_answer_questionId",
                table: "answer",
                column: "questionId");

            migrationBuilder.AddForeignKey(
                name: "FK_answer_questions_questionId",
                table: "answer",
                column: "questionId",
                principalTable: "questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_therapist_shift_employees_therapistId",
                table: "therapist_shift",
                column: "therapistId",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_therapist_shift_shifts_shiftId",
                table: "therapist_shift",
                column: "shiftId",
                principalTable: "shifts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class TherapistExpertise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_therapist_expertise_employees_therapistId",
                table: "therapist_expertise");

            migrationBuilder.DropForeignKey(
                name: "FK_therapist_expertise_expertises_expertiseId",
                table: "therapist_expertise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_therapist_expertise",
                table: "therapist_expertise");

            migrationBuilder.DropColumn(
                name: "therapist_expertise_id",
                table: "therapist_expertise");

            migrationBuilder.DropColumn(
                name: "expertise_id",
                table: "therapist_expertise");

            migrationBuilder.RenameColumn(
                name: "therapistId",
                table: "therapist_expertise",
                newName: "TherapistId");

            migrationBuilder.RenameColumn(
                name: "expertiseId",
                table: "therapist_expertise",
                newName: "ExpertiseId");

            migrationBuilder.RenameColumn(
                name: "experience",
                table: "therapist_expertise",
                newName: "Experience");

            migrationBuilder.RenameColumn(
                name: "therapist_id",
                table: "therapist_expertise",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_therapist_expertise_therapistId",
                table: "therapist_expertise",
                newName: "IX_therapist_expertise_TherapistId");

            migrationBuilder.RenameIndex(
                name: "IX_therapist_expertise_expertiseId",
                table: "therapist_expertise",
                newName: "IX_therapist_expertise_ExpertiseId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "therapist_expertise",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_therapist_expertise",
                table: "therapist_expertise",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_therapist_expertise_employees_TherapistId",
                table: "therapist_expertise",
                column: "TherapistId",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_therapist_expertise_expertises_ExpertiseId",
                table: "therapist_expertise",
                column: "ExpertiseId",
                principalTable: "expertises",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_therapist_expertise_employees_TherapistId",
                table: "therapist_expertise");

            migrationBuilder.DropForeignKey(
                name: "FK_therapist_expertise_expertises_ExpertiseId",
                table: "therapist_expertise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_therapist_expertise",
                table: "therapist_expertise");

            migrationBuilder.RenameColumn(
                name: "TherapistId",
                table: "therapist_expertise",
                newName: "therapistId");

            migrationBuilder.RenameColumn(
                name: "ExpertiseId",
                table: "therapist_expertise",
                newName: "expertiseId");

            migrationBuilder.RenameColumn(
                name: "Experience",
                table: "therapist_expertise",
                newName: "experience");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "therapist_expertise",
                newName: "therapist_id");

            migrationBuilder.RenameIndex(
                name: "IX_therapist_expertise_TherapistId",
                table: "therapist_expertise",
                newName: "IX_therapist_expertise_therapistId");

            migrationBuilder.RenameIndex(
                name: "IX_therapist_expertise_ExpertiseId",
                table: "therapist_expertise",
                newName: "IX_therapist_expertise_expertiseId");

            migrationBuilder.AlterColumn<int>(
                name: "therapist_id",
                table: "therapist_expertise",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "therapist_expertise_id",
                table: "therapist_expertise",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "expertise_id",
                table: "therapist_expertise",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_therapist_expertise",
                table: "therapist_expertise",
                column: "therapist_expertise_id");

            migrationBuilder.AddForeignKey(
                name: "FK_therapist_expertise_employees_therapistId",
                table: "therapist_expertise",
                column: "therapistId",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_therapist_expertise_expertises_expertiseId",
                table: "therapist_expertise",
                column: "expertiseId",
                principalTable: "expertises",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

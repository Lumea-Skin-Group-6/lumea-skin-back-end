using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDBFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "service_tags");

            migrationBuilder.DropTable(
                name: "tag");

            migrationBuilder.DropColumn(
                name: "shift_date",
                table: "shifts");

            migrationBuilder.AddColumn<DateTime>(
                name: "shift_date",
                table: "therapist_shift",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "recommended_age",
                table: "services",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "answer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    question_id = table.Column<int>(type: "integer", nullable: true),
                    content = table.Column<string>(type: "text", nullable: false),
                    dry_point = table.Column<short>(type: "smallint", nullable: false),
                    oily_point = table.Column<short>(type: "smallint", nullable: false),
                    sensitive_point = table.Column<short>(type: "smallint", nullable: false),
                    questionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_answer_questions_questionId",
                        column: x => x.questionId,
                        principalTable: "questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "skintypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    min_dry = table.Column<short>(type: "smallint", nullable: false),
                    max_dry = table.Column<short>(type: "smallint", nullable: false),
                    min_oily = table.Column<short>(type: "smallint", nullable: false),
                    max_oily = table.Column<short>(type: "smallint", nullable: false),
                    min_sensitive = table.Column<short>(type: "smallint", nullable: false),
                    max_sensitive = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skintypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "service_skin_type",
                columns: table => new
                {
                    service_id = table.Column<int>(type: "integer", nullable: false),
                    skin_type_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_service_skin_type", x => new { x.service_id, x.skin_type_id });
                    table.ForeignKey(
                        name: "FK_service_skin_type_services_service_id",
                        column: x => x.service_id,
                        principalTable: "services",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_service_skin_type_skintypes_skin_type_id",
                        column: x => x.skin_type_id,
                        principalTable: "skintypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_answer_questionId",
                table: "answer",
                column: "questionId");

            migrationBuilder.CreateIndex(
                name: "IX_service_skin_type_skin_type_id",
                table: "service_skin_type",
                column: "skin_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "answer");

            migrationBuilder.DropTable(
                name: "service_skin_type");

            migrationBuilder.DropTable(
                name: "skintypes");

            migrationBuilder.DropColumn(
                name: "shift_date",
                table: "therapist_shift");

            migrationBuilder.DropColumn(
                name: "recommended_age",
                table: "services");

            migrationBuilder.AddColumn<DateTime>(
                name: "shift_date",
                table: "shifts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "tag",
                columns: table => new
                {
                    tag_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    questionId = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    question_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tag", x => x.tag_id);
                    table.ForeignKey(
                        name: "FK_tag_questions_questionId",
                        column: x => x.questionId,
                        principalTable: "questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "service_tags",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    service_id = table.Column<int>(type: "integer", nullable: false),
                    tag_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_service_tags", x => x.id);
                    table.ForeignKey(
                        name: "FK_service_tags_services_service_id",
                        column: x => x.service_id,
                        principalTable: "services",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_service_tags_tag_tag_id",
                        column: x => x.tag_id,
                        principalTable: "tag",
                        principalColumn: "tag_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_service_tags_service_id",
                table: "service_tags",
                column: "service_id");

            migrationBuilder.CreateIndex(
                name: "IX_service_tags_tag_id",
                table: "service_tags",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_tag_questionId",
                table: "tag",
                column: "questionId");
        }
    }
}

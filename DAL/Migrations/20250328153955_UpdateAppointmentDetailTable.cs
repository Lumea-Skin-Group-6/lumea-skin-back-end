using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAppointmentDetailTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointment_detail_dates_appointment_details_appointment_de~",
                table: "appointment_detail_dates");

            migrationBuilder.DropIndex(
                name: "IX_appointment_detail_dates_appointment_detail_id1",
                table: "appointment_detail_dates");

            migrationBuilder.DropColumn(
                name: "appointment_detail_id1",
                table: "appointment_detail_dates");

            migrationBuilder.AlterColumn<string>(
                name: "service_type",
                table: "appointment_details",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_detail_dates_appointment_detail_id",
                table: "appointment_detail_dates",
                column: "appointment_detail_id");

            migrationBuilder.AddForeignKey(
                name: "FK_appointment_detail_dates_appointment_details_appointment_de~",
                table: "appointment_detail_dates",
                column: "appointment_detail_id",
                principalTable: "appointment_details",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointment_detail_dates_appointment_details_appointment_de~",
                table: "appointment_detail_dates");

            migrationBuilder.DropIndex(
                name: "IX_appointment_detail_dates_appointment_detail_id",
                table: "appointment_detail_dates");

            migrationBuilder.AlterColumn<int>(
                name: "service_type",
                table: "appointment_details",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "appointment_detail_id1",
                table: "appointment_detail_dates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_appointment_detail_dates_appointment_detail_id1",
                table: "appointment_detail_dates",
                column: "appointment_detail_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_appointment_detail_dates_appointment_details_appointment_de~",
                table: "appointment_detail_dates",
                column: "appointment_detail_id1",
                principalTable: "appointment_details",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

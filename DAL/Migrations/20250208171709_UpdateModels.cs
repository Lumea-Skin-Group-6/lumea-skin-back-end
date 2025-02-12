using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Role_RoleId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Account_AccountId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDetail_Appointment_AppointmentId",
                table: "AppointmentDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDetail_Employee_TherapistId",
                table: "AppointmentDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDetail_Service_ServiceId",
                table: "AppointmentDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDetailDate_AppointmentDetail_AppointmentDetailId",
                table: "AppointmentDetailDate");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Account_AccountId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceExpertise_Expertise_ExpertiseId",
                table: "ServiceExpertise");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceExpertise_Service_ServiceId",
                table: "ServiceExpertise");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTag_Service_ServiceId",
                table: "ServiceTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTag_Tag_TagId",
                table: "ServiceTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Slot_Employee_EmployeeId",
                table: "Slot");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Question_QuestionId",
                table: "Tag");

            migrationBuilder.DropForeignKey(
                name: "FK_TherapistExpertise_Employee_TherapistId",
                table: "TherapistExpertise");

            migrationBuilder.DropForeignKey(
                name: "FK_TherapistExpertise_Expertise_ExpertiseId",
                table: "TherapistExpertise");

            migrationBuilder.DropForeignKey(
                name: "FK_TherapistShift_Employee_TherapistId",
                table: "TherapistShift");

            migrationBuilder.DropForeignKey(
                name: "FK_TherapistShift_Shift_ShiftId",
                table: "TherapistShift");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Slot",
                table: "Slot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TherapistShift",
                table: "TherapistShift");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TherapistExpertise",
                table: "TherapistExpertise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shift",
                table: "Shift");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceTag",
                table: "ServiceTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceExpertise",
                table: "ServiceExpertise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expertise",
                table: "Expertise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DailyReport",
                table: "DailyReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentDetailDate",
                table: "AppointmentDetailDate");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentDetailDate_AppointmentDetailId",
                table: "AppointmentDetailDate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentDetail",
                table: "AppointmentDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                table: "Account");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "tag");

            migrationBuilder.RenameTable(
                name: "Slot",
                newName: "slot");

            migrationBuilder.RenameTable(
                name: "TherapistShift",
                newName: "therapist_shift");

            migrationBuilder.RenameTable(
                name: "TherapistExpertise",
                newName: "therapist_expertise");

            migrationBuilder.RenameTable(
                name: "Shift",
                newName: "shifts");

            migrationBuilder.RenameTable(
                name: "ServiceTag",
                newName: "service_tags");

            migrationBuilder.RenameTable(
                name: "ServiceExpertise",
                newName: "service_expertises");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "services");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "roles");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "questions");

            migrationBuilder.RenameTable(
                name: "Expertise",
                newName: "expertises");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "employees");

            migrationBuilder.RenameTable(
                name: "DailyReport",
                newName: "daily_reports");

            migrationBuilder.RenameTable(
                name: "AppointmentDetailDate",
                newName: "appointment_detail_dates");

            migrationBuilder.RenameTable(
                name: "AppointmentDetail",
                newName: "appointment_details");

            migrationBuilder.RenameTable(
                name: "Appointment",
                newName: "appointments");

            migrationBuilder.RenameTable(
                name: "Account",
                newName: "accounts");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "tag",
                newName: "questionId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tag",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tag",
                newName: "question_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tag_QuestionId",
                table: "tag",
                newName: "IX_tag_questionId");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "slot",
                newName: "time");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "slot",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "slot",
                newName: "employeeId");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "slot",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "slot",
                newName: "employee_id");

            migrationBuilder.RenameIndex(
                name: "IX_Slot_EmployeeId",
                table: "slot",
                newName: "IX_slot_employeeId");

            migrationBuilder.RenameColumn(
                name: "TherapistId",
                table: "therapist_shift",
                newName: "therapistId");

            migrationBuilder.RenameColumn(
                name: "ShiftId",
                table: "therapist_shift",
                newName: "shiftId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "therapist_shift",
                newName: "therapist_id");

            migrationBuilder.RenameIndex(
                name: "IX_TherapistShift_TherapistId",
                table: "therapist_shift",
                newName: "IX_therapist_shift_therapistId");

            migrationBuilder.RenameIndex(
                name: "IX_TherapistShift_ShiftId",
                table: "therapist_shift",
                newName: "IX_therapist_shift_shiftId");

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
                name: "IX_TherapistExpertise_TherapistId",
                table: "therapist_expertise",
                newName: "IX_therapist_expertise_therapistId");

            migrationBuilder.RenameIndex(
                name: "IX_TherapistExpertise_ExpertiseId",
                table: "therapist_expertise",
                newName: "IX_therapist_expertise_expertiseId");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "shifts",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "shifts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "shifts",
                newName: "start_time");

            migrationBuilder.RenameColumn(
                name: "MinStaff",
                table: "shifts",
                newName: "min_staff");

            migrationBuilder.RenameColumn(
                name: "MaxStaff",
                table: "shifts",
                newName: "max_staff");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "shifts",
                newName: "end_time");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "shifts",
                newName: "shift_date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "service_tags",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "service_tags",
                newName: "tag_id");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "service_tags",
                newName: "service_id");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceTag_TagId",
                table: "service_tags",
                newName: "IX_service_tags_tag_id");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceTag_ServiceId",
                table: "service_tags",
                newName: "IX_service_tags_service_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "service_expertises",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "service_expertises",
                newName: "service_id");

            migrationBuilder.RenameColumn(
                name: "ExpertiseId",
                table: "service_expertises",
                newName: "expertise_id");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceExpertise_ServiceId",
                table: "service_expertises",
                newName: "IX_service_expertises_service_id");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceExpertise_ExpertiseId",
                table: "service_expertises",
                newName: "IX_service_expertises_expertise_id");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "services",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "services",
                newName: "duration");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "services",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "services",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "services",
                newName: "service_type");

            migrationBuilder.RenameColumn(
                name: "RecommendedPeriodStartTime",
                table: "services",
                newName: "recommended_start_time");

            migrationBuilder.RenameColumn(
                name: "RecommendedPeriodEndTime",
                table: "services",
                newName: "recommended_end_time");

            migrationBuilder.RenameColumn(
                name: "NumberOfTreatment",
                table: "services",
                newName: "number_of_treatments");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "services",
                newName: "service_name");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "services",
                newName: "image_url");

            migrationBuilder.RenameColumn(
                name: "ExperienceRequired",
                table: "services",
                newName: "experience_required");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "roles",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "roles",
                newName: "role_name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "questions",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SurveyId",
                table: "questions",
                newName: "survey_id");

            migrationBuilder.RenameColumn(
                name: "ServiceType",
                table: "questions",
                newName: "service_type");

            migrationBuilder.RenameColumn(
                name: "QuestionContent",
                table: "questions",
                newName: "question_content");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "questions",
                newName: "display_order");

            migrationBuilder.RenameColumn(
                name: "IsMultipleChoice",
                table: "questions",
                newName: "is_multiple_choice");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "questions",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "expertises",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ExpertiseName",
                table: "expertises",
                newName: "expertise_name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "employees",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "employees",
                newName: "role_type");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "employees",
                newName: "account_id");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_AccountId",
                table: "employees",
                newName: "IX_employees_account_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "daily_reports",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TotalRevenue",
                table: "daily_reports",
                newName: "total_revenue");

            migrationBuilder.RenameColumn(
                name: "TotalBookings",
                table: "daily_reports",
                newName: "total_bookings");

            migrationBuilder.RenameColumn(
                name: "NetRevenue",
                table: "daily_reports",
                newName: "net_revenue");

            migrationBuilder.RenameColumn(
                name: "DiscountsApplied",
                table: "daily_reports",
                newName: "discounts_applied");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "daily_reports",
                newName: "report_date");

            migrationBuilder.RenameColumn(
                name: "CompletedBookings",
                table: "daily_reports",
                newName: "completed_bookings");

            migrationBuilder.RenameColumn(
                name: "CancelledBookings",
                table: "daily_reports",
                newName: "cancelled_bookings");

            migrationBuilder.RenameColumn(
                name: "CancellationFees",
                table: "daily_reports",
                newName: "cancellation_fees");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "appointment_detail_dates",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "appointment_detail_dates",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "AppointmentDetailId",
                table: "appointment_detail_dates",
                newName: "appointment_detail_id");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "appointment_details",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "appointment_details",
                newName: "rating");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "appointment_details",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "appointment_details",
                newName: "duration");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "appointment_details",
                newName: "comment");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "appointment_details",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "appointment_details",
                newName: "service_type");

            migrationBuilder.RenameColumn(
                name: "TherapistNote",
                table: "appointment_details",
                newName: "therapist_note");

            migrationBuilder.RenameColumn(
                name: "TherapistId",
                table: "appointment_details",
                newName: "therapist_id");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "appointment_details",
                newName: "start_time");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "appointment_details",
                newName: "service_id");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "appointment_details",
                newName: "end_time");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "appointment_details",
                newName: "appointment_id");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentDetail_TherapistId",
                table: "appointment_details",
                newName: "IX_appointment_details_therapist_id");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentDetail_ServiceId",
                table: "appointment_details",
                newName: "IX_appointment_details_service_id");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentDetail_AppointmentId",
                table: "appointment_details",
                newName: "IX_appointment_details_appointment_id");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "appointments",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "appointments",
                newName: "note");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "appointments",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "appointments",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "appointments",
                newName: "appointment_date");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "appointments",
                newName: "account_id");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_AccountId",
                table: "appointments",
                newName: "IX_appointments_account_id");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "accounts",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "accounts",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "accounts",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "accounts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "accounts",
                newName: "account_status");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "accounts",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "accounts",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "accounts",
                newName: "password_hash");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "accounts",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "accounts",
                newName: "image_url");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "accounts",
                newName: "full_name");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "accounts",
                newName: "date_of_birth");

            migrationBuilder.RenameIndex(
                name: "IX_Account_RoleId",
                table: "accounts",
                newName: "IX_accounts_role_id");

            migrationBuilder.AlterColumn<int>(
                name: "question_id",
                table: "tag",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "tag_id",
                table: "tag",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "employee_id",
                table: "slot",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "slot_id",
                table: "slot",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "therapist_id",
                table: "therapist_shift",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "therapist_shift_id",
                table: "therapist_shift",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "shift_id",
                table: "therapist_shift",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddColumn<int>(
                name: "appointment_detail_id1",
                table: "appointment_detail_dates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tag",
                table: "tag",
                column: "tag_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_slot",
                table: "slot",
                column: "slot_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_therapist_shift",
                table: "therapist_shift",
                column: "therapist_shift_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_therapist_expertise",
                table: "therapist_expertise",
                column: "therapist_expertise_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shifts",
                table: "shifts",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_service_tags",
                table: "service_tags",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_service_expertises",
                table: "service_expertises",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_services",
                table: "services",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_questions",
                table: "questions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_expertises",
                table: "expertises",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employees",
                table: "employees",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_daily_reports",
                table: "daily_reports",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointment_detail_dates",
                table: "appointment_detail_dates",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointment_details",
                table: "appointment_details",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointments",
                table: "appointments",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_accounts",
                table: "accounts",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_detail_dates_appointment_detail_id1",
                table: "appointment_detail_dates",
                column: "appointment_detail_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_roles_role_id",
                table: "accounts",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointment_detail_dates_appointment_details_appointment_de~",
                table: "appointment_detail_dates",
                column: "appointment_detail_id1",
                principalTable: "appointment_details",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointment_details_appointments_appointment_id",
                table: "appointment_details",
                column: "appointment_id",
                principalTable: "appointments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointment_details_employees_therapist_id",
                table: "appointment_details",
                column: "therapist_id",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointment_details_services_service_id",
                table: "appointment_details",
                column: "service_id",
                principalTable: "services",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_accounts_account_id",
                table: "appointments",
                column: "account_id",
                principalTable: "accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employees_accounts_account_id",
                table: "employees",
                column: "account_id",
                principalTable: "accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_service_expertises_expertises_expertise_id",
                table: "service_expertises",
                column: "expertise_id",
                principalTable: "expertises",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_service_expertises_services_service_id",
                table: "service_expertises",
                column: "service_id",
                principalTable: "services",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_service_tags_services_service_id",
                table: "service_tags",
                column: "service_id",
                principalTable: "services",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_service_tags_tag_tag_id",
                table: "service_tags",
                column: "tag_id",
                principalTable: "tag",
                principalColumn: "tag_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_slot_employees_employeeId",
                table: "slot",
                column: "employeeId",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tag_questions_questionId",
                table: "tag",
                column: "questionId",
                principalTable: "questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_roles_role_id",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_appointment_detail_dates_appointment_details_appointment_de~",
                table: "appointment_detail_dates");

            migrationBuilder.DropForeignKey(
                name: "FK_appointment_details_appointments_appointment_id",
                table: "appointment_details");

            migrationBuilder.DropForeignKey(
                name: "FK_appointment_details_employees_therapist_id",
                table: "appointment_details");

            migrationBuilder.DropForeignKey(
                name: "FK_appointment_details_services_service_id",
                table: "appointment_details");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_accounts_account_id",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_employees_accounts_account_id",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_service_expertises_expertises_expertise_id",
                table: "service_expertises");

            migrationBuilder.DropForeignKey(
                name: "FK_service_expertises_services_service_id",
                table: "service_expertises");

            migrationBuilder.DropForeignKey(
                name: "FK_service_tags_services_service_id",
                table: "service_tags");

            migrationBuilder.DropForeignKey(
                name: "FK_service_tags_tag_tag_id",
                table: "service_tags");

            migrationBuilder.DropForeignKey(
                name: "FK_slot_employees_employeeId",
                table: "slot");

            migrationBuilder.DropForeignKey(
                name: "FK_tag_questions_questionId",
                table: "tag");

            migrationBuilder.DropForeignKey(
                name: "FK_therapist_expertise_employees_therapistId",
                table: "therapist_expertise");

            migrationBuilder.DropForeignKey(
                name: "FK_therapist_expertise_expertises_expertiseId",
                table: "therapist_expertise");

            migrationBuilder.DropForeignKey(
                name: "FK_therapist_shift_employees_therapistId",
                table: "therapist_shift");

            migrationBuilder.DropForeignKey(
                name: "FK_therapist_shift_shifts_shiftId",
                table: "therapist_shift");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tag",
                table: "tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_slot",
                table: "slot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_therapist_shift",
                table: "therapist_shift");

            migrationBuilder.DropPrimaryKey(
                name: "PK_therapist_expertise",
                table: "therapist_expertise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shifts",
                table: "shifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_services",
                table: "services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_service_tags",
                table: "service_tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_service_expertises",
                table: "service_expertises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_questions",
                table: "questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_expertises",
                table: "expertises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employees",
                table: "employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_daily_reports",
                table: "daily_reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appointments",
                table: "appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appointment_details",
                table: "appointment_details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appointment_detail_dates",
                table: "appointment_detail_dates");

            migrationBuilder.DropIndex(
                name: "IX_appointment_detail_dates_appointment_detail_id1",
                table: "appointment_detail_dates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_accounts",
                table: "accounts");

            migrationBuilder.DropColumn(
                name: "tag_id",
                table: "tag");

            migrationBuilder.DropColumn(
                name: "slot_id",
                table: "slot");

            migrationBuilder.DropColumn(
                name: "therapist_shift_id",
                table: "therapist_shift");

            migrationBuilder.DropColumn(
                name: "shift_id",
                table: "therapist_shift");

            migrationBuilder.DropColumn(
                name: "therapist_expertise_id",
                table: "therapist_expertise");

            migrationBuilder.DropColumn(
                name: "expertise_id",
                table: "therapist_expertise");

            migrationBuilder.DropColumn(
                name: "appointment_detail_id1",
                table: "appointment_detail_dates");

            migrationBuilder.RenameTable(
                name: "tag",
                newName: "Tag");

            migrationBuilder.RenameTable(
                name: "slot",
                newName: "Slot");

            migrationBuilder.RenameTable(
                name: "therapist_shift",
                newName: "TherapistShift");

            migrationBuilder.RenameTable(
                name: "therapist_expertise",
                newName: "TherapistExpertise");

            migrationBuilder.RenameTable(
                name: "shifts",
                newName: "Shift");

            migrationBuilder.RenameTable(
                name: "services",
                newName: "Service");

            migrationBuilder.RenameTable(
                name: "service_tags",
                newName: "ServiceTag");

            migrationBuilder.RenameTable(
                name: "service_expertises",
                newName: "ServiceExpertise");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "questions",
                newName: "Question");

            migrationBuilder.RenameTable(
                name: "expertises",
                newName: "Expertise");

            migrationBuilder.RenameTable(
                name: "employees",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "daily_reports",
                newName: "DailyReport");

            migrationBuilder.RenameTable(
                name: "appointments",
                newName: "Appointment");

            migrationBuilder.RenameTable(
                name: "appointment_details",
                newName: "AppointmentDetail");

            migrationBuilder.RenameTable(
                name: "appointment_detail_dates",
                newName: "AppointmentDetailDate");

            migrationBuilder.RenameTable(
                name: "accounts",
                newName: "Account");

            migrationBuilder.RenameColumn(
                name: "questionId",
                table: "Tag",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Tag",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "question_id",
                table: "Tag",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_tag_questionId",
                table: "Tag",
                newName: "IX_Tag_QuestionId");

            migrationBuilder.RenameColumn(
                name: "time",
                table: "Slot",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Slot",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "employeeId",
                table: "Slot",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Slot",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "employee_id",
                table: "Slot",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_slot_employeeId",
                table: "Slot",
                newName: "IX_Slot_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "therapistId",
                table: "TherapistShift",
                newName: "TherapistId");

            migrationBuilder.RenameColumn(
                name: "shiftId",
                table: "TherapistShift",
                newName: "ShiftId");

            migrationBuilder.RenameColumn(
                name: "therapist_id",
                table: "TherapistShift",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_therapist_shift_therapistId",
                table: "TherapistShift",
                newName: "IX_TherapistShift_TherapistId");

            migrationBuilder.RenameIndex(
                name: "IX_therapist_shift_shiftId",
                table: "TherapistShift",
                newName: "IX_TherapistShift_ShiftId");

            migrationBuilder.RenameColumn(
                name: "therapistId",
                table: "TherapistExpertise",
                newName: "TherapistId");

            migrationBuilder.RenameColumn(
                name: "expertiseId",
                table: "TherapistExpertise",
                newName: "ExpertiseId");

            migrationBuilder.RenameColumn(
                name: "experience",
                table: "TherapistExpertise",
                newName: "Experience");

            migrationBuilder.RenameColumn(
                name: "therapist_id",
                table: "TherapistExpertise",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_therapist_expertise_therapistId",
                table: "TherapistExpertise",
                newName: "IX_TherapistExpertise_TherapistId");

            migrationBuilder.RenameIndex(
                name: "IX_therapist_expertise_expertiseId",
                table: "TherapistExpertise",
                newName: "IX_TherapistExpertise_ExpertiseId");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Shift",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Shift",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "start_time",
                table: "Shift",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "shift_date",
                table: "Shift",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "min_staff",
                table: "Shift",
                newName: "MinStaff");

            migrationBuilder.RenameColumn(
                name: "max_staff",
                table: "Shift",
                newName: "MaxStaff");

            migrationBuilder.RenameColumn(
                name: "end_time",
                table: "Shift",
                newName: "EndTime");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Service",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "duration",
                table: "Service",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Service",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Service",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "service_type",
                table: "Service",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "service_name",
                table: "Service",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "recommended_start_time",
                table: "Service",
                newName: "RecommendedPeriodStartTime");

            migrationBuilder.RenameColumn(
                name: "recommended_end_time",
                table: "Service",
                newName: "RecommendedPeriodEndTime");

            migrationBuilder.RenameColumn(
                name: "number_of_treatments",
                table: "Service",
                newName: "NumberOfTreatment");

            migrationBuilder.RenameColumn(
                name: "image_url",
                table: "Service",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "experience_required",
                table: "Service",
                newName: "ExperienceRequired");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ServiceTag",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "tag_id",
                table: "ServiceTag",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "service_id",
                table: "ServiceTag",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_service_tags_tag_id",
                table: "ServiceTag",
                newName: "IX_ServiceTag_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_service_tags_service_id",
                table: "ServiceTag",
                newName: "IX_ServiceTag_ServiceId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ServiceExpertise",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "service_id",
                table: "ServiceExpertise",
                newName: "ServiceId");

            migrationBuilder.RenameColumn(
                name: "expertise_id",
                table: "ServiceExpertise",
                newName: "ExpertiseId");

            migrationBuilder.RenameIndex(
                name: "IX_service_expertises_service_id",
                table: "ServiceExpertise",
                newName: "IX_ServiceExpertise_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_service_expertises_expertise_id",
                table: "ServiceExpertise",
                newName: "IX_ServiceExpertise_ExpertiseId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Role",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "role_name",
                table: "Role",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Question",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "survey_id",
                table: "Question",
                newName: "SurveyId");

            migrationBuilder.RenameColumn(
                name: "service_type",
                table: "Question",
                newName: "ServiceType");

            migrationBuilder.RenameColumn(
                name: "question_content",
                table: "Question",
                newName: "QuestionContent");

            migrationBuilder.RenameColumn(
                name: "is_multiple_choice",
                table: "Question",
                newName: "IsMultipleChoice");

            migrationBuilder.RenameColumn(
                name: "display_order",
                table: "Question",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Question",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Expertise",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "expertise_name",
                table: "Expertise",
                newName: "ExpertiseName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Employee",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "role_type",
                table: "Employee",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "account_id",
                table: "Employee",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_employees_account_id",
                table: "Employee",
                newName: "IX_Employee_AccountId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "DailyReport",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "total_revenue",
                table: "DailyReport",
                newName: "TotalRevenue");

            migrationBuilder.RenameColumn(
                name: "total_bookings",
                table: "DailyReport",
                newName: "TotalBookings");

            migrationBuilder.RenameColumn(
                name: "report_date",
                table: "DailyReport",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "net_revenue",
                table: "DailyReport",
                newName: "NetRevenue");

            migrationBuilder.RenameColumn(
                name: "discounts_applied",
                table: "DailyReport",
                newName: "DiscountsApplied");

            migrationBuilder.RenameColumn(
                name: "completed_bookings",
                table: "DailyReport",
                newName: "CompletedBookings");

            migrationBuilder.RenameColumn(
                name: "cancelled_bookings",
                table: "DailyReport",
                newName: "CancelledBookings");

            migrationBuilder.RenameColumn(
                name: "cancellation_fees",
                table: "DailyReport",
                newName: "CancellationFees");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Appointment",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "note",
                table: "Appointment",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "Appointment",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Appointment",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "appointment_date",
                table: "Appointment",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "account_id",
                table: "Appointment",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_account_id",
                table: "Appointment",
                newName: "IX_Appointment_AccountId");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "AppointmentDetail",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "rating",
                table: "AppointmentDetail",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "AppointmentDetail",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "duration",
                table: "AppointmentDetail",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "comment",
                table: "AppointmentDetail",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AppointmentDetail",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "therapist_note",
                table: "AppointmentDetail",
                newName: "TherapistNote");

            migrationBuilder.RenameColumn(
                name: "therapist_id",
                table: "AppointmentDetail",
                newName: "TherapistId");

            migrationBuilder.RenameColumn(
                name: "start_time",
                table: "AppointmentDetail",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "service_type",
                table: "AppointmentDetail",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "service_id",
                table: "AppointmentDetail",
                newName: "ServiceId");

            migrationBuilder.RenameColumn(
                name: "end_time",
                table: "AppointmentDetail",
                newName: "EndTime");

            migrationBuilder.RenameColumn(
                name: "appointment_id",
                table: "AppointmentDetail",
                newName: "AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_appointment_details_therapist_id",
                table: "AppointmentDetail",
                newName: "IX_AppointmentDetail_TherapistId");

            migrationBuilder.RenameIndex(
                name: "IX_appointment_details_service_id",
                table: "AppointmentDetail",
                newName: "IX_AppointmentDetail_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_appointment_details_appointment_id",
                table: "AppointmentDetail",
                newName: "IX_AppointmentDetail_AppointmentId");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "AppointmentDetailDate",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AppointmentDetailDate",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "appointment_detail_id",
                table: "AppointmentDetailDate",
                newName: "AppointmentDetailId");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Account",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Account",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Account",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Account",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "Account",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "Account",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "password_hash",
                table: "Account",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "Account",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "image_url",
                table: "Account",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "full_name",
                table: "Account",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "date_of_birth",
                table: "Account",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "account_status",
                table: "Account",
                newName: "Status");

            migrationBuilder.RenameIndex(
                name: "IX_accounts_role_id",
                table: "Account",
                newName: "IX_Account_RoleId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Tag",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Slot",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TherapistShift",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TherapistExpertise",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slot",
                table: "Slot",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TherapistShift",
                table: "TherapistShift",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TherapistExpertise",
                table: "TherapistExpertise",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shift",
                table: "Shift",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceTag",
                table: "ServiceTag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceExpertise",
                table: "ServiceExpertise",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expertise",
                table: "Expertise",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DailyReport",
                table: "DailyReport",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentDetail",
                table: "AppointmentDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentDetailDate",
                table: "AppointmentDetailDate",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                table: "Account",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDetailDate_AppointmentDetailId",
                table: "AppointmentDetailDate",
                column: "AppointmentDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Role_RoleId",
                table: "Account",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Account_AccountId",
                table: "Appointment",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDetail_Appointment_AppointmentId",
                table: "AppointmentDetail",
                column: "AppointmentId",
                principalTable: "Appointment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDetail_Employee_TherapistId",
                table: "AppointmentDetail",
                column: "TherapistId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDetail_Service_ServiceId",
                table: "AppointmentDetail",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDetailDate_AppointmentDetail_AppointmentDetailId",
                table: "AppointmentDetailDate",
                column: "AppointmentDetailId",
                principalTable: "AppointmentDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Account_AccountId",
                table: "Employee",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceExpertise_Expertise_ExpertiseId",
                table: "ServiceExpertise",
                column: "ExpertiseId",
                principalTable: "Expertise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceExpertise_Service_ServiceId",
                table: "ServiceExpertise",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTag_Service_ServiceId",
                table: "ServiceTag",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTag_Tag_TagId",
                table: "ServiceTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Slot_Employee_EmployeeId",
                table: "Slot",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Question_QuestionId",
                table: "Tag",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TherapistExpertise_Employee_TherapistId",
                table: "TherapistExpertise",
                column: "TherapistId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TherapistExpertise_Expertise_ExpertiseId",
                table: "TherapistExpertise",
                column: "ExpertiseId",
                principalTable: "Expertise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TherapistShift_Employee_TherapistId",
                table: "TherapistShift",
                column: "TherapistId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TherapistShift_Shift_ShiftId",
                table: "TherapistShift",
                column: "ShiftId",
                principalTable: "Shift",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

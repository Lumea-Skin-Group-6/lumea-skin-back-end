﻿// <auto-generated />
using System;
using DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BusinessObject.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ActivationCode")
                        .HasColumnType("text")
                        .HasColumnName("activation_code");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<bool>("Gender")
                        .HasColumnType("boolean")
                        .HasColumnName("gender");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text")
                        .HasColumnName("image_url");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<bool>("IsLoggedIn")
                        .HasColumnType("boolean")
                        .HasColumnName("is_logged_in");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text")
                        .HasColumnName("refresh_token");

                    b.Property<DateTime?>("RefreshTokenExpiry")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("refresh_token_expiry");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer")
                        .HasColumnName("role_id");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("account_status");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("BusinessObject.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<short>("DryPoint")
                        .HasColumnType("smallint")
                        .HasColumnName("dry_point");

                    b.Property<short>("OilyPoint")
                        .HasColumnType("smallint")
                        .HasColumnName("oily_point");

                    b.Property<short>("SensitivePoint")
                        .HasColumnType("smallint")
                        .HasColumnName("sensitive_point");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("questionId")
                        .HasColumnType("integer");

                    b.Property<int?>("question_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("questionId");

                    b.ToTable("answer");
                });

            modelBuilder.Entity("BusinessObject.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer")
                        .HasColumnName("account_id");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("appointment_date");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("note");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("appointments");
                });

            modelBuilder.Entity("BusinessObject.AppointmentDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentId")
                        .HasColumnType("integer")
                        .HasColumnName("appointment_id");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval")
                        .HasColumnName("duration");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_time");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<decimal>("Rating")
                        .HasColumnType("numeric")
                        .HasColumnName("rating");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer")
                        .HasColumnName("service_id");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_time");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<int>("TherapistId")
                        .HasColumnType("integer")
                        .HasColumnName("therapist_id");

                    b.Property<string>("TherapistNote")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("therapist_note");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("service_type");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("TherapistId");

                    b.ToTable("appointment_details");
                });

            modelBuilder.Entity("BusinessObject.AppointmentDetailDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentDetailId")
                        .HasColumnType("integer")
                        .HasColumnName("appointment_detail_id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date");

                    b.Property<int>("appointment_detail_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("appointment_detail_id");

                    b.ToTable("appointment_detail_dates", t =>
                        {
                            t.Property("appointment_detail_id")
                                .HasColumnName("appointment_detail_id1");
                        });
                });

            modelBuilder.Entity("BusinessObject.DailyReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("CancellationFees")
                        .HasColumnType("numeric")
                        .HasColumnName("cancellation_fees");

                    b.Property<int>("CancelledBookings")
                        .HasColumnType("integer")
                        .HasColumnName("cancelled_bookings");

                    b.Property<int>("CompletedBookings")
                        .HasColumnType("integer")
                        .HasColumnName("completed_bookings");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("report_date");

                    b.Property<decimal>("DiscountsApplied")
                        .HasColumnType("numeric")
                        .HasColumnName("discounts_applied");

                    b.Property<decimal>("NetRevenue")
                        .HasColumnType("numeric")
                        .HasColumnName("net_revenue");

                    b.Property<int>("TotalBookings")
                        .HasColumnType("integer")
                        .HasColumnName("total_bookings");

                    b.Property<decimal>("TotalRevenue")
                        .HasColumnType("numeric")
                        .HasColumnName("total_revenue");

                    b.HasKey("Id");

                    b.ToTable("daily_reports");
                });

            modelBuilder.Entity("BusinessObject.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer")
                        .HasColumnName("account_id");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("role_type");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("BusinessObject.Expertise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ExpertiseName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("expertise_name");

                    b.HasKey("Id");

                    b.ToTable("expertises");
                });

            modelBuilder.Entity("BusinessObject.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsMultipleChoice")
                        .HasColumnType("boolean")
                        .HasColumnName("is_multiple_choice");

                    b.Property<int>("Order")
                        .HasColumnType("integer")
                        .HasColumnName("display_order");

                    b.Property<string>("QuestionContent")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("question_content");

                    b.Property<int>("ServiceType")
                        .HasColumnType("integer")
                        .HasColumnName("service_type");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("questions");
                });

            modelBuilder.Entity("BusinessObject.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("role_name");

                    b.HasKey("Id");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("BusinessObject.ServiceExpertise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ExpertiseId")
                        .HasColumnType("integer")
                        .HasColumnName("expertise_id");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer")
                        .HasColumnName("service_id");

                    b.HasKey("Id");

                    b.HasIndex("ExpertiseId");

                    b.HasIndex("ServiceId");

                    b.ToTable("service_expertises");
                });

            modelBuilder.Entity("BusinessObject.ServiceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval")
                        .HasColumnName("duration");

                    b.Property<string>("ExperienceRequired")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("experience_required");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image_url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("service_name");

                    b.Property<int>("NumberOfTreatment")
                        .HasColumnType("integer")
                        .HasColumnName("number_of_treatments");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<int>("RecommendedAge")
                        .HasColumnType("integer")
                        .HasColumnName("recommended_age");

                    b.Property<DateTime>("RecommendedPeriodEndTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("recommended_end_time");

                    b.Property<DateTime>("RecommendedPeriodStartTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("recommended_start_time");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("service_type");

                    b.HasKey("Id");

                    b.ToTable("services");
                });

            modelBuilder.Entity("BusinessObject.Shift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_time");

                    b.Property<int>("MaxStaff")
                        .HasColumnType("integer")
                        .HasColumnName("max_staff");

                    b.Property<int>("MaxTherapist")
                        .HasColumnType("integer")
                        .HasColumnName("max_therapist");

                    b.Property<int>("MinStaff")
                        .HasColumnType("integer")
                        .HasColumnName("min_staff");

                    b.Property<int>("MinTherapist")
                        .HasColumnType("integer")
                        .HasColumnName("min_therapist");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_time");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.ToTable("shifts");
                });

            modelBuilder.Entity("BusinessObject.SkinType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<short>("MaxDry")
                        .HasColumnType("smallint")
                        .HasColumnName("max_dry");

                    b.Property<short>("MaxOily")
                        .HasColumnType("smallint")
                        .HasColumnName("max_oily");

                    b.Property<short>("MaxSensitive")
                        .HasColumnType("smallint")
                        .HasColumnName("max_sensitive");

                    b.Property<short>("MinDry")
                        .HasColumnType("smallint")
                        .HasColumnName("min_dry");

                    b.Property<short>("MinOily")
                        .HasColumnType("smallint")
                        .HasColumnName("min_oily");

                    b.Property<short>("MinSensitive")
                        .HasColumnType("smallint")
                        .HasColumnName("min_sensitive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("skintypes");
                });

            modelBuilder.Entity("BusinessObject.SkinTypeService", b =>
                {
                    b.Property<int>("ServiceId")
                        .HasColumnType("integer")
                        .HasColumnName("service_id");

                    b.Property<int>("SkinTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("skin_type_id");

                    b.HasKey("ServiceId", "SkinTypeId");

                    b.HasIndex("SkinTypeId");

                    b.ToTable("service_skin_type");
                });

            modelBuilder.Entity("BusinessObject.Slot", b =>
                {
                    b.Property<int>("slot_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("slot_id"));

                    b.Property<DateTime>("date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("employee_id")
                        .HasColumnType("integer");


                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("time")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("slot_id");

                    b.HasIndex("employee_id");

                    b.ToTable("slot");
                });

            modelBuilder.Entity("BusinessObject.TherapistExpertise", b =>
                {
                    b.Property<int>("therapist_expertise_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("therapist_expertise_id"));

                    b.Property<int>("experience")
                        .HasColumnType("integer");

                    b.Property<int>("expertiseId")
                        .HasColumnType("integer");

                    b.Property<int>("expertise_id")
                        .HasColumnType("integer");

                    b.Property<int>("therapistId")
                        .HasColumnType("integer");

                    b.Property<int>("therapist_id")
                        .HasColumnType("integer");

                    b.HasKey("therapist_expertise_id");

                    b.HasIndex("expertiseId");

                    b.HasIndex("therapistId");

                    b.ToTable("therapist_expertise");
                });

            modelBuilder.Entity("BusinessObject.TherapistShift", b =>
                {
                    b.Property<int>("therapist_shift_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("therapist_shift_id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date");

                    b.Property<int>("shift_id")
                        .HasColumnType("integer")
                        .HasColumnName("shift_id");

                    b.Property<int>("therapist_id")
                        .HasColumnType("integer")
                        .HasColumnName("therapist_id");

                    b.HasKey("therapist_shift_id");

                    b.ToTable("therapist_shift");
                });

            modelBuilder.Entity("BusinessObject.Account", b =>
                {
                    b.HasOne("BusinessObject.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BusinessObject.Answer", b =>
                {
                    b.HasOne("BusinessObject.Question", "question")
                        .WithMany()
                        .HasForeignKey("questionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("question");
                });

            modelBuilder.Entity("BusinessObject.Appointment", b =>
                {
                    b.HasOne("BusinessObject.Account", "Account")
                        .WithMany("Appointments")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("BusinessObject.AppointmentDetail", b =>
                {
                    b.HasOne("BusinessObject.Appointment", "Appointment")
                        .WithMany("AppointmentDetails")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObject.ServiceModel", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObject.Employee", "Therapist")
                        .WithMany()
                        .HasForeignKey("TherapistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Service");

                    b.Navigation("Therapist");
                });

            modelBuilder.Entity("BusinessObject.AppointmentDetailDate", b =>
                {
                    b.HasOne("BusinessObject.AppointmentDetail", "AppointmentDetail")
                        .WithMany("AppointmentDetailDates")
                        .HasForeignKey("appointment_detail_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppointmentDetail");
                });

            modelBuilder.Entity("BusinessObject.Employee", b =>
                {
                    b.HasOne("BusinessObject.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("BusinessObject.ServiceExpertise", b =>
                {
                    b.HasOne("BusinessObject.Expertise", "Expertise")
                        .WithMany()
                        .HasForeignKey("ExpertiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObject.ServiceModel", "Service")
                        .WithMany("ServiceExpertises")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Expertise");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("BusinessObject.SkinTypeService", b =>
                {
                    b.HasOne("BusinessObject.ServiceModel", "Service")
                        .WithMany("SkinTypeServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObject.SkinType", "SkinType")
                        .WithMany()
                        .HasForeignKey("SkinTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("SkinType");
                });

            modelBuilder.Entity("BusinessObject.Slot", b =>
                {
                    b.HasOne("BusinessObject.Employee", "employee")
                        .WithMany("Slots")
                        .HasForeignKey("employeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employee");
                });

            modelBuilder.Entity("BusinessObject.TherapistExpertise", b =>
                {
                    b.HasOne("BusinessObject.Expertise", "expertise")
                        .WithMany("TherapistExpertises")
                        .HasForeignKey("expertiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObject.Employee", "therapist")
                        .WithMany()
                        .HasForeignKey("therapistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("expertise");

                    b.Navigation("therapist");
                });

            modelBuilder.Entity("BusinessObject.TherapistShift", b =>
                {
                    b.HasOne("BusinessObject.Shift", "shift")
                        .WithMany("TherapistShifts")
                        .HasForeignKey("shiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObject.Employee", "therapist")
                        .WithMany()
                        .HasForeignKey("therapistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("shift");

                    b.Navigation("therapist");
                });

            modelBuilder.Entity("BusinessObject.Account", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("BusinessObject.Appointment", b =>
                {
                    b.Navigation("AppointmentDetails");
                });

            modelBuilder.Entity("BusinessObject.AppointmentDetail", b =>
                {
                    b.Navigation("AppointmentDetailDates");
                });

            modelBuilder.Entity("BusinessObject.Employee", b =>
                {
                    b.Navigation("Slots");
                });

            modelBuilder.Entity("BusinessObject.Expertise", b =>
                {
                    b.Navigation("TherapistExpertises");
                });

            modelBuilder.Entity("BusinessObject.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("BusinessObject.ServiceModel", b =>
                {
                    b.Navigation("ServiceExpertises");

                    b.Navigation("SkinTypeServices");
                });

            modelBuilder.Entity("BusinessObject.Shift", b =>
                {
                    b.Navigation("TherapistShifts");
                });
#pragma warning restore 612, 618
        }
    }
}

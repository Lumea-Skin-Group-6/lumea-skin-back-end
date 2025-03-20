using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSets
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<TherapistShift> TherapistShifts { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentDetail> AppointmentDetails { get; set; }
        public DbSet<AppointmentDetailDate> AppointmentDetailDates { get; set; }
        public DbSet<Expertise> Expertises { get; set; }
        public DbSet<TherapistExpertise> TherapistExpertises { get; set; }
        public DbSet<ServiceModel> Services { get; set; }
        public DbSet<ServiceExpertise> ServiceExpertises { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<SkinType> SkinTypes { get; set; }
        public DbSet<SkinTypeService> ServiceSkinTypes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<DailyReport> DailyReports { get; set; }

        private static string? GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
            return configuration["ConnectionStrings:PostGresServer"];
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(GetConnectionString());

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkinTypeService>()
               .HasKey(sts => new { sts.ServiceId, sts.SkinTypeId });

            modelBuilder.Entity<Answer>()
               .HasOne(a => a.question)
               .WithMany(q => q.Answers)
               .HasForeignKey(a => a.question_id)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Account>()
               .HasOne(a => a.Employee)
               .WithOne(e => e.Account)
               .HasForeignKey<Employee>(e => e.AccountId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
               .Entity<ServiceModel>()
               .Property(e => e.Type)
               .HasConversion<string>();

            modelBuilder.Entity<Expertise>()
                .HasMany(e => e.TherapistExpertises)
                .WithOne(t => t.Expertise)
                .HasForeignKey(t => t.ExpertiseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.TherapistExpertises)
                .WithOne(t => t.Therapist)
                .HasForeignKey(t => t.TherapistId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
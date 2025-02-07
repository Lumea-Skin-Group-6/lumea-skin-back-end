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
        public AppDbContext() { }
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
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceExpertise> ServiceExpertises { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ServiceTag> ServiceTags { get; set; }
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
            // Configure relationships and keys here

            //modelBuilder.Entity<Account>()
            //    .HasOne(a => a.Role)
            //    .WithMany()
            //    .HasForeignKey(a => a.RoleId);

            //modelBuilder.Entity<Employee>()
            //    .HasOne(e => e.Account)
            //    .WithOne()
            //    .HasForeignKey<Employee>(e => e.AccountId);

            //modelBuilder.Entity<Slot>()
            //    .HasOne(s => s.Employee)
            //    .WithMany()
            //    .HasForeignKey(s => s.EmployeeId);

            //modelBuilder.Entity<TherapistShift>()
            //    .HasOne(ts => ts.Therapist)
            //    .WithMany()
            //    .HasForeignKey(ts => ts.TherapistId);

            //modelBuilder.Entity<TherapistShift>()
            //    .HasOne(ts => ts.Shift)
            //    .WithMany()
            //    .HasForeignKey(ts => ts.ShiftId);

            //modelBuilder.Entity<Appointment>()
            //    .HasOne(a => a.Account)
            //    .WithMany()
            //    .HasForeignKey(a => a.AccountId);

            //modelBuilder.Entity<AppointmentDetail>()
            //    .HasOne(ad => ad.Appointment)
            //    .WithMany()
            //    .HasForeignKey(ad => ad.AppointmentId);

            //modelBuilder.Entity<AppointmentDetail>()
            //    .HasOne(ad => ad.Service)
            //    .WithMany()
            //    .HasForeignKey(ad => ad.ServiceId);

            //modelBuilder.Entity<AppointmentDetail>()
            //    .HasOne(ad => ad.Therapist)
            //    .WithMany()
            //    .HasForeignKey(ad => ad.TherapistId);

            //modelBuilder.Entity<AppointmentDetailDate>()
            //    .HasOne(add => add.AppointmentDetail)
            //    .WithMany()
            //    .HasForeignKey(add => add.AppointmentDetailId);

            //modelBuilder.Entity<TherapistExpertise>()
            //    .HasOne(te => te.Therapist)
            //    .WithMany()
            //    .HasForeignKey(te => te.TherapistId);

            //modelBuilder.Entity<TherapistExpertise>()
            //    .HasOne(te => te.Expertise)
            //    .WithMany()
            //    .HasForeignKey(te => te.ExpertiseId);

            //modelBuilder.Entity<ServiceExpertise>()
            //    .HasOne(se => se.Service)
            //    .WithMany()
            //    .HasForeignKey(se => se.ServiceId);

            //modelBuilder.Entity<ServiceExpertise>()
            //    .HasOne(se => se.Expertise)
            //    .WithMany()
            //    .HasForeignKey(se => se.ExpertiseId);

            //modelBuilder.Entity<ServiceTag>()
            //    .HasOne(st => st.Service)
            //    .WithMany()
            //    .HasForeignKey(st => st.ServiceId);

            //modelBuilder.Entity<ServiceTag>()
            //    .HasOne(st => st.Tag)
            //    .WithMany()
            //    .HasForeignKey(st => st.TagId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

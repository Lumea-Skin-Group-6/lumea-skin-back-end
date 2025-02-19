using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    [Table("appointment_details")]
    public class AppointmentDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("appointment_id")] public int AppointmentId { get; set; }

        [Column("service_id")] public int ServiceId { get; set; }

        [Column("therapist_id")] public int TherapistId { get; set; }

        [Column("price")] public decimal Price { get; set; }

        [Column("service_type")] public string Type { get; set; }

        [Column("rating")] public decimal Rating { get; set; }

        [Column("comment")] public string Comment { get; set; }

        [Column("duration")] public TimeSpan Duration { get; set; }

        [Column("status")] public string Status { get; set; }

        [Column("therapist_note")] public string TherapistNote { get; set; }

        [Column("start_time")] public DateTime StartTime { get; set; }

        [Column("end_time")] public DateTime EndTime { get; set; }

        public Appointment Appointment { get; set; }
        public ServiceModel Service { get; set; }
        public Employee Therapist { get; set; }
        public ICollection<AppointmentDetailDate> AppointmentDetailDates { get; set; }
    }
}
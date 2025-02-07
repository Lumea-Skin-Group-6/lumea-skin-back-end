using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("AppointmentDetail")]
    public class AppointmentDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public int ServiceId { get; set; }
        public int TherapistId { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public decimal Rating { get; set; }
        public string Comment { get; set; }
        public TimeSpan Duration { get; set; }
        public string Status { get; set; }
        public string TherapistNote { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        //[ForeignKey(nameof(AppointmentId))]
        public Appointment Appointment { get; set; }

        //[ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; }

        //[ForeignKey(nameof(TherapistId))]
        public Employee Therapist { get; set; }

        public ICollection<AppointmentDetailDate> AppointmentDetailDates { get; set; }
    }
}

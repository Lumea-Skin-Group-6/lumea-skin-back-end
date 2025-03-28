using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("appointment_detail_dates")]
    public class AppointmentDetailDate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("appointment_detail_id")] public int AppointmentDetailId { get; set; }

        [JsonIgnore]
        public AppointmentDetail AppointmentDetail { get; set; }

        [Column("date")] public DateTime Date { get; set; }
    }
}
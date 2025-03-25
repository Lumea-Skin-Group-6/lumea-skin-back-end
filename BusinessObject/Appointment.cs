using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace BusinessObject
{
    [Table("appointments")]
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("account_id")] public int AccountId { get; set; }

        [Column("appointment_date")] public DateTime Date { get; set; }

        [Column("note")] public string? Note { get; set; }

        [Column("amount")] public decimal Amount { get; set; }

        [Column("status")] public string Status { get; set; }

        [JsonIgnore]
        public Account Account { get; set; }
        public ICollection<AppointmentDetail> AppointmentDetails { get; set; }
    }
}
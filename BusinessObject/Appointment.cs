using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("Appointment")]
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }

        //[ForeignKey(nameof(AccountId))]
        public Account Account { get; set; }
        public ICollection<AppointmentDetail> AppointmentDetails { get; set; }
    }
}

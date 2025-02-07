using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("AppointmentDetailDate")]
    public class AppointmentDetailDate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AppointmentDetailId { get; set; }

        //[ForeignKey(nameof(AppointmentDetailId))]
        public AppointmentDetail AppointmentDetail { get; set; }
        public DateTime Date { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("TherapistShift")]
    public class TherapistShift
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TherapistId { get; set; }
        public int ShiftId { get; set; }

        //[ForeignKey(nameof(TherapistId))]
        public Employee Therapist { get; set; }

        //[ForeignKey(nameof(ShiftId))]
        public Shift Shift { get; set; }
    }

}

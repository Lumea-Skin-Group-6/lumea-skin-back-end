using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("therapist_shift")]
    public class TherapistShift
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int therapist_shift_id { get; set; }


        [Column("therapist_id")]
        public int therapist_id { get; set; }

        [Column("shift_id")]
        public int shift_id { get; set; }


        [Column("date")]
        public DateTime Date { get; set; }

        [ForeignKey(nameof(therapist_id))]
        public Employee therapist { get; set; }

        [ForeignKey(nameof(shift_id))]
        public Shift shift { get; set; }
    }
}
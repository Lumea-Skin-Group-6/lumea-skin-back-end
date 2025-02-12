using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("shifts")]
    public class Shift
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("shift_date")]
        public DateTime Date { get; set; }

        [Column("start_time")]
        public DateTime StartTime { get; set; }

        [Column("end_time")]
        public DateTime EndTime { get; set; }

        [Column("min_staff")]
        public int MinStaff { get; set; }

        [Column("max_staff")]
        public int MaxStaff { get; set; }

        [Column("min_therapist")]
        public int MinTherapist {  get; set; }

        [Column("max_therapist")]
        public int MaxTherapist { get; set; }

        [Column("status")]
        public string Status { get; set; }

        public ICollection<TherapistShift> TherapistShifts { get; set; }
    }

}

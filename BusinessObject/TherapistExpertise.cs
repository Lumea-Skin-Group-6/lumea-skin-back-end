using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("therapist_expertise")]
    public class TherapistExpertise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int therapist_expertise_id { get; set; }

        public int therapist_id { get; set; }
        public int expertise_id { get; set; }

        //[ForeignKey(nameof(therapist_id))]
        public Employee therapist { get; set; }

        //[ForeignKey(nameof(expertise_id))]
        public Expertise expertise { get; set; }
        public int experience { get; set; }
    }
}
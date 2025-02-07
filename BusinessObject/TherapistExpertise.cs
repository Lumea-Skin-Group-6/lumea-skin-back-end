using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("TherapistExpertise")]
    public class TherapistExpertise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TherapistId { get; set; }
        public int ExpertiseId { get; set; }

        //[ForeignKey(nameof(TherapistId))]
        public Employee Therapist { get; set; }

        //[ForeignKey(nameof(ExpertiseId))]
        public Expertise Expertise { get; set; }
        public int Experience { get; set; }
    }
}

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
        public int Id { get; set; }
        public int TherapistId { get; set; }
        public int ExpertiseId { get; set; }
        public Employee? Therapist { get; set; }
        public Expertise? Expertise { get; set; }
        public int Experience { get; set; }
    }
}
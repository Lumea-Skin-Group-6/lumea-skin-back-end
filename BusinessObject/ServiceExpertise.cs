using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("ServiceExpertise")]
    public class ServiceExpertise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int ExpertiseId { get; set; }

        //[ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; }

        //[ForeignKey(nameof(ExpertiseId))]
        public Expertise Expertise { get; set; }
    }
}

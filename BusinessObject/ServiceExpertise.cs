using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("service_expertises")]
    public class ServiceExpertise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("service_id")]
        public int ServiceId { get; set; }

        [Column("expertise_id")]
        public int ExpertiseId { get; set; }

        public ServiceModel Service { get; set; }
        public Expertise Expertise { get; set; }
    }

}

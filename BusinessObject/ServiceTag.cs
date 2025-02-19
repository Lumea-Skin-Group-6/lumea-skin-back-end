using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("service_tags")]
    public class ServiceTag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("service_id")] public int ServiceId { get; set; }

        [Column("tag_id")] public int TagId { get; set; }

        public ServiceModel Service { get; set; }
        public Tag Tag { get; set; }
    }
}
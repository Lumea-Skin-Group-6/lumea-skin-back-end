using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("ServiceTag")]
    public class ServiceTag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int TagId { get; set; }

        //[ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; }

        //[ForeignKey(nameof(TagId))]
        public Tag Tag { get; set; }
    }
}

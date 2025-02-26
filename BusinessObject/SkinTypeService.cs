using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("service_skin_type")]
    public class SkinTypeService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("service_id")]
        public int ServiceId { get; set; }

        [Column("skin_type_id")]
        public int SkinTypeId { get; set; }

        public ServiceModel Service { get; set; }
        public SkinType SkinType { get; set; }
    }
}

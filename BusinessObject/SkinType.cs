using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("skintypes")]
    public class SkinType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")] public string Name { get; set; }

        [Column("min_dry")] public string MinDry { get; set; }

        [Column("max_dry")] public string MaxDry { get; set; }

        [Column("min_oily")] public string MinOily { get; set; }

        [Column("max_oily")] public string MaxOily { get; set; }

        [Column("min_sensitive")] public string MinSensitive { get; set; }

        [Column("max_sensitive")] public string MaxSensitive { get; set; }

    }
}

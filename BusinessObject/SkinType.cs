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

        [Column("description")] public string Description { get; set; }

        [Column("min_dry")] public sbyte MinDry { get; set; }

        [Column("max_dry")] public sbyte MaxDry { get; set; }

        [Column("min_oily")] public sbyte MinOily { get; set; }

        [Column("max_oily")] public sbyte MaxOily { get; set; }

        [Column("min_sensitive")] public sbyte MinSensitive { get; set; }

        [Column("max_sensitive")] public sbyte MaxSensitive { get; set; }

    }
}

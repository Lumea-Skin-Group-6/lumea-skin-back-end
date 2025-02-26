using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("answer")]
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? question_id { get; set; }
        public string content { get; set; }

        [Column("dry_point")] public sbyte DryPoint { get; set; }

        [Column("oily_point")] public sbyte OilyPoint { get; set; }

        [Column("sensitive_point")] public sbyte SensitivePoint { get; set; }

        //[ForeignKey(nameof(question_id))]
        public Question question { get; set; }
    }
}
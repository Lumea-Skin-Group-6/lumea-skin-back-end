using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("tag")]
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int tag_id { get; set; }

        public int question_id { get; set; }
        public string name { get; set; }

        //[ForeignKey(nameof(question_id))]
        public Question question { get; set; }
    }
}
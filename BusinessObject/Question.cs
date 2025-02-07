using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Table("Question")]
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string QuestionContent { get; set; }
        public string ServiceType { get; set; }
        public bool IsMultipleChoice { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Order { get; set; }
        public int SurveyId { get; set; }
    }
}

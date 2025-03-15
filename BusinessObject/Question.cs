using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject
{
    [Table("questions")]
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("question_content")] public string QuestionContent { get; set; }

        [Column("is_multiple_choice")] public bool IsMultipleChoice { get; set; }

        [Column("updated_at")] public DateTime UpdatedAt { get; set; }

        [Column("status")] public bool Active { get; set; }

        public ICollection<Answer>? Answers { get; set; }
    }
}
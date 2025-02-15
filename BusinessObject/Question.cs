﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [Column("service_type")] public ServiceType ServiceType { get; set; }

        [Column("is_multiple_choice")] public bool IsMultipleChoice { get; set; }

        [Column("created_at")] public DateTime CreatedAt { get; set; }

        [Column("display_order")] public int Order { get; set; }
    }
}
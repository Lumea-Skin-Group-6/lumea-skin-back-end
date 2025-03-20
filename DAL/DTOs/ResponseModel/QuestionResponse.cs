using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.ResponseModel
{
    public class QuestionResponse
    {
        public int Id { get; set; }
        public string QuestionContent { get; set; }
        public bool IsMultipleChoice { get; set; }
        public bool Active { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<AnswerResponse> Answers { get; set; } = new();
    }

    public class QuestionResponseWithAnswer
    {
        public int Id { get; set; }
        public string QuestionContent { get; set; }
        public bool IsMultipleChoice { get; set; }
        public bool Active { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<AnswerResponse> Answers { get; set; } = new();
    }
}

using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.ResponseModel
{
    public class QuestionResponse
    {
        public int Id { get; set; }

        public string QuestionContent { get; set; }

        public ServiceType ServiceType { get; set; }

        public bool IsMultipleChoice { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int Order { get; set; }
    }
}

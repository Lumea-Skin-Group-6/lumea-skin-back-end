using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class QuestionDTO
    {

        public string QuestionContent { get; set; }

        public ServiceType ServiceType { get; set; }

        public bool IsMultipleChoice { get; set; }

        public DateTime CreatedAt { get; set; }

        public int Order { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.ResponseModel
{
    public class AnswerResponse
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public sbyte DryPoint { get; set; }

        public sbyte OilyPoint { get; set; }

        public sbyte SensitivePoint { get; set; }
    }
}

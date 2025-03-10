using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.RequestModel
{
    public class AnswerUpdateRequest
    {
        [Required(ErrorMessage = "Id is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Id.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Content must be between 3 and 50 characters.")]
        public string Content { get; set; }

        [Range(-10, 10, ErrorMessage = "DryPoint must be between -10 and 10.")]
        public sbyte DryPoint { get; set; }

        [Range(-10, 10, ErrorMessage = "OilyPoint must be between -10 and 10.")]
        public sbyte OilyPoint { get; set; }

        [Range(-10, 10, ErrorMessage = "SensitivePoint must be between -10 and 10.")]
        public sbyte SensitivePoint { get; set; }
    }
}

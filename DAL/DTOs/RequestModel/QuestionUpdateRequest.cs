using BusinessObject;
using DAL.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.RequestModel
{
    public class QuestionUpdateRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        [StringLength(100, ErrorMessage = "Content cannot exceed 100 characters.")]
        public string QuestionContent { get; set; }

        [Required(ErrorMessage = "ServiceType is required.")]
        [EnumValidation(typeof(ServiceType), ErrorMessage = "Invalid ServiceType value.")]
        public ServiceType ServiceType { get; set; }

        public bool IsMultipleChoice { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Order must be at least 1.")]
        public int Order { get; set; }
    }
}

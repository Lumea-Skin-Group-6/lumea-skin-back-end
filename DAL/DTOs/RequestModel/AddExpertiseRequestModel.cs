using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.RequestModel
{
    public class AddExpertiseRequestModel
    {
        [Required(ErrorMessage = "ExpertiseName is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "ExpertiseName must be at least 2 characters long.")]
        public string ExpertiseName { get; set; } = "";
    }
}

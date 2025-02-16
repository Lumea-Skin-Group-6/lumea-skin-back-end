using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.RequestModel
{
    public class TagCreateRequest
    {
        [Required(ErrorMessage = "Content is required.")]
        [StringLength(50, ErrorMessage = "Content cannot exceed 50 characters.")]
        public string name { get; set; }
    }
}

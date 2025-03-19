using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.RequestModel
{
    public class UpdateSkinTypeRequestModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; } = "";

        [StringLength(10000, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string Description { get; set; } = "";

        [Range(0, 100, ErrorMessage = "MinDry must be between 0 and 100.")]
        public sbyte MinDry { get; set; }

        [Range(0, 100, ErrorMessage = "MaxDry must be between 0 and 100.")]
        public sbyte MaxDry { get; set; }

        [Range(0, 100, ErrorMessage = "MinOily must be between 0 and 100.")]
        public sbyte MinOily { get; set; }

        [Range(0, 100, ErrorMessage = "MaxOily must be between 0 and 100.")]
        public sbyte MaxOily { get; set; }

        [Range(0, 100, ErrorMessage = "MinSensitive must be between 0 and 100.")]
        public sbyte MinSensitive { get; set; }

        [Range(0, 100, ErrorMessage = "MaxSensitive must be between 0 and 100.")]
        public sbyte MaxSensitive { get; set; }
    }
}

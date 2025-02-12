
using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO.Expertise
{
    public class ExpertiseDTO
    {
        public int Id { get; set; }

        public string ExpertiseName { get; set; } = "";
    }
}

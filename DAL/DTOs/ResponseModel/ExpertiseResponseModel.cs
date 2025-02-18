
using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DBContext;

namespace DAL.DTOs.ResponseModel
{
    public class ExpertiseResponseModel
    {
        public int Id { get; set; }

        public string ExpertiseName { get; set; } = "";
    }
}

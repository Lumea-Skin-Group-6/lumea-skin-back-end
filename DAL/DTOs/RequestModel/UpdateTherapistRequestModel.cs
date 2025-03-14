using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.RequestModel
{
    public class UpdateTherapistRequestModel
    {
        public int employeeId {  get; set; }
        public int AccountId { get; set; }

     
        public string Type { get; set; }
    }
}

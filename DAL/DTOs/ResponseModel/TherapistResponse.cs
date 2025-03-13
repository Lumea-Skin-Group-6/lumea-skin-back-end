using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.ResponseModel
{
    public class TherapistResponse
    {
        public int AccountID { get; set; }
        public string TherapistName { get; set; }

        public string TherapistType { get; set; }
    }
}

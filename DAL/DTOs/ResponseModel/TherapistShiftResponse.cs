using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.ResponseModel
{
    public class TherapistShiftResponse
    {
        public int TherapistShiftId { get; set; }
        public int TherapistId { get; set; }
        public int ShiftId { get; set; }
        public DateTime Date { get; set; }
    }
}

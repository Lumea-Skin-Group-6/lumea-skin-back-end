using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.RequestModel
{
    public class TherapistShiftDateRequest
    {
        public int ShiftId { get; set; }
        public List<DateTime> Dates {  get; set; }
    }
}

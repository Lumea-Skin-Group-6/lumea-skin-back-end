using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.ResponseModel
{
    public class TherapistShiftGroupedDto
    {
        public DateTime Date { get; set; }
        public ICollection<int> TherapistIds { get; set; }
    }
}

using BusinessObject;
using DAL.DTOs.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public static class TherapistShiftMapper
    {
        public static TherapistShiftResponse ToResponse(this TherapistShift model)
        {
            return new TherapistShiftResponse
            {
                Date = model.Date,
                ShiftId = model.shift_id,
                TherapistId = model.therapist_id,
                TherapistShiftId = model.therapist_shift_id,
            };
        }
    }
}

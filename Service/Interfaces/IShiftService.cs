

using BusinessObject;
using DAL.DTO;
using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;

namespace Service.Interfaces
{
    public interface IShiftService
    {
        List<Shift> GetAllShift();
        ResponseModel GetShiftById(int id);
        public ResponseModel AddShift(int id, ShiftRequestDTO shiftRequest);
        public ResponseModel UpdateAsync(int id, ShiftRequestDTO shift);
        public ResponseModel DeleteAsync(int id);

        List<TherapistShiftGroupedDto> GetAllTherapistShift();

        public ResponseModel AddTherapistShift(int therapistID, List<DateTime> dateTimes);


        List<Shift> GetShiftsByTherapistId(int therapistID);

        public ResponseModel DeleteTherapistShift(int  therapistID);

        public ResponseModel UpdateTherapistShift(int TherapistID, int therapistShiftID,  DateTime Datetime);
    }
}
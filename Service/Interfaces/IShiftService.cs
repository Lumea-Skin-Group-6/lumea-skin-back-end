

using BusinessObject;
using DAL.DTO;
using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;

namespace Service.Interfaces
{
    public interface IShiftService
    {
        List<Shift> GetAllShift();
        ShiftResponseModel GetShiftById(int id);
        public ShiftResponseModel AddShift(ShiftRequestDTO shift);
        public ShiftResponseModel UpdateAsync(int id, ShiftRequestDTO shift);
        public ShiftResponseModel DeleteAsync(int id);
    }
}
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO.Shift;
using DAL.DTO.ShiftDTO;
using DAL.DTO;
namespace Service
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

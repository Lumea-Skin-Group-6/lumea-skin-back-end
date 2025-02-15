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
        ResponseDTO GetShiftById(int id);
        public ResponseDTO AddShift(ShiftRequestDTO shift);
        public ResponseDTO UpdateAsync(int id, ShiftRequestDTO shift);
        public ResponseDTO DeleteAsync(int id);
    }
}

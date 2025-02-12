using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO.Shift;
using DAL.DTO.ShiftDTO;
namespace Service
{
    public interface IShiftService
    {
        List<Shift> GetAllShift();
        Shift GetShiftById(int id);
        public ShiftResponseDTO AddAsync(ShiftRequestDTO shift);
        void UpdateAsync(Shift shift);
        void DeleteAsync(int id);
    }
}

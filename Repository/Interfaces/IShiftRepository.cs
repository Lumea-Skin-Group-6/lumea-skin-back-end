using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.DTO;
namespace Repository
{
    public interface IShiftRepository
    {
        List<Shift> GetAllShift();
        Shift GetShiftById(int id);
        void AddAsync(Shift shift);
        void UpdateAsync(Shift shift);
        void DeleteAsync(Shift shift);
    }
}

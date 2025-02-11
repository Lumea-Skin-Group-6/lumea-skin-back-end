using BusinessObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ShiftService : IShiftService
    {

        private readonly IShiftRepository _shiftRepo;

        public ShiftService(IShiftRepository shiftRepo)
        {
            _shiftRepo = shiftRepo;
        }

        public void AddAsync(Shift shift)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<Shift> GetAllShift()
        {
            return _shiftRepo.GetAllShift();
        }

        public Shift GetShiftById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(Shift shift)
        {
            throw new NotImplementedException();
        }
    }
}

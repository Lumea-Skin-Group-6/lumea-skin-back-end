using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ISlotService
    {
        Task<List<Slot>> GetFreeSlotsOfTherapist(int employeeID);
        Task<List<Shift>> GenerateShifts(string shiftName, DateTime dateTime);
    }
}

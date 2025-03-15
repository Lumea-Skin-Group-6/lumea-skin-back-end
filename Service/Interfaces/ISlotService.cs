using BusinessObject;
using DAL.DTO;
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

        ResponseModel AddSlot();
    }
}

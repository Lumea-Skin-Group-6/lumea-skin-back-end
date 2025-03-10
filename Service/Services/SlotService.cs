using BusinessObject;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SlotService : ISlotService
    {
        private readonly ISlotRepository _slotRepository;

        public SlotService(ISlotRepository slotRepository)
        {
            _slotRepository = slotRepository;
        }


        public async Task<List<Slot>> GetFreeSlotsOfTherapist(int employeeID)
        {
            return await _slotRepository.GetFreeSlotsByTherapistIdAsync(employeeID);
        }
    }
}

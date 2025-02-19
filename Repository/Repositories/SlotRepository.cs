using BusinessObject;
using DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class SlotRepository : ISlotRepository
    {
        private readonly AppDbContext _context;

        public SlotRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Slot>> GetFreeSlotsByTherapistIdAsync(int therapistId)
        {
            var freeSlots = await _context.Slots
                .Where(s => s.status == "Free" &&
                            _context.TherapistShifts
                                .Where(ts => ts.therapist_id == therapistId)
                                .Select(ts => ts.therapist_shift_id)
                                .Contains(_context.Shifts
                                    .Where(sh => sh.Date == s.date)
                                    .Select(sh => sh.Id)
                                    .FirstOrDefault()))
                .ToListAsync();

            return freeSlots;
        }
    }
}

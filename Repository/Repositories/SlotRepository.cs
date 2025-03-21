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

        public void AddSlot(Slot slot)
        {
            _context.Slots.Add(slot);
            _context.SaveChanges();
        }

        public async Task<List<Slot>> GetFreeSlotsByTherapistIdAsync(int employeeId)
        {
            var today = DateTime.UtcNow.Date; 
            var startOfWeek = today.AddDays(-(int)today.DayOfWeek); 
            var endOfWeek = startOfWeek.AddDays(7); 

            var freeSlots = await _context.Slots
                .Where(s => s.status == "Available" &&
                            s.date >= startOfWeek && s.date <= endOfWeek &&
                            s.employee_id == employeeId && s.employee.Type == "Therapist")
                .ToListAsync();

            return freeSlots;
        }

        public List<Slot> GetSlots()
        {
            return _context.Slots.ToList();
        }
    }
}

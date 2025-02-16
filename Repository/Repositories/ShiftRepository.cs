using BusinessObject;
using DAL.DBContext;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ShiftRepository : IShiftRepository
    {

        private readonly AppDbContext _context;

        public ShiftRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddAsync(Shift shift)
        {
            _context.Shifts.Add(shift);
            _context.SaveChangesAsync();
        }

        public void DeleteAsync(Shift shift)
        {
            
                _context.Shifts.Remove(shift);
                _context.SaveChangesAsync();
            
        }

        public List<Shift> GetAllShift()
        {
            return _context.Shifts.ToList();
        }

        public Shift GetShiftById(int id)
        {
            return _context.Shifts.Find(id);
        }

        public void UpdateAsync(Shift shift)
        {      
               _context.Shifts.Update(shift);
                _context.SaveChangesAsync();         
        }
    }
}

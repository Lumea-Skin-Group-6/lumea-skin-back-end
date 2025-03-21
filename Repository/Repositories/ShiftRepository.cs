﻿using BusinessObject;
using DAL.DBContext;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly AppDbContext _context;

        public ShiftRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddShift(Shift shift)
        {
            _context.Shifts.Add(shift);
            _context.SaveChanges();
        }

        public void DeleteAsync(Shift shift)
        {
            _context.Shifts.Remove(shift);
            _context.SaveChanges();
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
            _context.SaveChanges();
        }

        public void AddTherapistShift(TherapistShift therapistShift)
        {
            _context.TherapistShifts.Add(therapistShift);
            _context.SaveChanges();
        }

        public List<TherapistShift> GetAllTherapistShift()
        {
            return _context.TherapistShifts.ToList();
        }

        public TherapistShift GetTherapistShift(int id)
        {
            return _context.TherapistShifts.Find(id);
        }

        public void UpdateTherapistShift(TherapistShift therapistShift)
        {
            _context.TherapistShifts.Update(therapistShift);
            _context.SaveChanges();
        }

        public List<Shift> GetShiftsByTherapistId(int id)
        {
            return _context.TherapistShifts
                   .Where(ts => ts.therapist_id == id)
                   .Select(ts => ts.shift)
                   .ToList();
        }
    }
}
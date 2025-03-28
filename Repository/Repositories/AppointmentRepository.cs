using BusinessObject;
using DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _context;
        public AppointmentRepository(AppDbContext context) => _context = context;

        public async Task<bool> IsSlotAvailableAsync(int? therapistId, DateTime startTime, TimeSpan duration)
        {
            var endTime = startTime.Add(duration);

            var slots = await _context.Slots
                .Where(s => s.employee_id == therapistId && s.date.Date == startTime.Date)
                .ToListAsync();
            if (slots.IsNullOrEmpty())
            {
                return false;
            }
            return !slots.Any(s =>
                TimeSpan.Parse(s.time) >= startTime.TimeOfDay &&
                TimeSpan.Parse(s.time) < endTime.TimeOfDay &&
                (s.status.Equals("Booked") || s.status.Equals("Closed"))
            );
        }

        public async Task BookSlotsAsync(int? therapistId, DateTime startTime, TimeSpan duration)
        {
            var endTime = startTime.Add(duration);
            var slots = await _context.Slots
                .Where(s => s.employee_id == therapistId && s.date.Date == startTime.Date)
                .ToListAsync(); 

            var slotsToBook = slots
                .Where(s => TimeSpan.Parse(s.time) >= startTime.TimeOfDay &&
                            TimeSpan.Parse(s.time) < endTime.TimeOfDay)
                .ToList();


            foreach (var slot in slotsToBook)
            {
                slot.status = "Booked";
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Appointment?> AddAppointmentAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }
        public async Task<Appointment?> UpdateAppointmentAsync(Appointment appointment)
        {
            var existingAppointment = await _context.Appointments
                .Include(a => a.AppointmentDetails)
                .ThenInclude(d => d.AppointmentDetailDates)
                .FirstOrDefaultAsync(a => a.Id == appointment.Id);

            if (existingAppointment == null)
            {
                return null;
            }

            // Update scalar properties of Appointment
            _context.Entry(existingAppointment).CurrentValues.SetValues(appointment);

            // Handle AppointmentDetails
            var updatedDetailIds = appointment.AppointmentDetails.Select(d => d.Id).ToList();

            // Remove old details not in the updated list
            var detailsToRemove = existingAppointment.AppointmentDetails
                .Where(d => !updatedDetailIds.Contains(d.Id))
                .ToList(); // Convert to List to avoid modifying the collection during iteration

            foreach (var detail in detailsToRemove)
            {
                _context.AppointmentDetails.Remove(detail);
            }

            foreach (var detail in appointment.AppointmentDetails)
            {
                var existingDetail = existingAppointment.AppointmentDetails.FirstOrDefault(d => d.Id == detail.Id);
                if (existingDetail != null)
                {
                    // Update existing detail
                    _context.Entry(existingDetail).CurrentValues.SetValues(detail);

                    // Handle AppointmentDetailDates
                    var updatedDateIds = detail.AppointmentDetailDates.Select(dd => dd.Id).ToList();

                    var datesToRemove = existingDetail.AppointmentDetailDates
                        .Where(dd => !updatedDateIds.Contains(dd.Id))
                        .ToList();

                    foreach (var date in datesToRemove)
                    {
                        _context.AppointmentDetailDates.Remove(date);
                    }

                    foreach (var detailDate in detail.AppointmentDetailDates)
                    {
                        var existingDate = existingDetail.AppointmentDetailDates.FirstOrDefault(dd => dd.Id == detailDate.Id);
                        if (existingDate != null)
                        {
                            _context.Entry(existingDate).CurrentValues.SetValues(detailDate);
                        }
                        else
                        {
                            existingDetail.AppointmentDetailDates.Add(detailDate);
                        }
                    }
                }
                else
                {
                    // Add new details
                    existingAppointment.AppointmentDetails.Add(detail);
                }
            }

            await _context.SaveChangesAsync();
            return existingAppointment;
        }

        public async Task<Appointment?> GetAppointmentByIdAsync(int id)
        {
            return await _context.Appointments
                .Include(a => a.AppointmentDetails)
                .ThenInclude(d => d.AppointmentDetailDates)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentAsync()
        {
            return await _context.Appointments
                .Include(a => a.AppointmentDetails)
                .ThenInclude(d => d.AppointmentDetailDates)
                .ToListAsync();
        }

        public async Task<bool> CancelAppointment(int id)
        {
            var appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == id);

            if (appointment == null)
                return false;
            if (appointment.Status.Equals("Booked"))
            {
                appointment.Status = "Cancelled";
                await _context.SaveChangesAsync();
                return true;
            }           
            return false;
        }
        public async Task<List<Appointment>> GetAppointmentHistoryByUserIdAsync(int userId)
        {
            return await _context.Appointments
                .Where(a => a.AccountId == userId)
                .Include(a => a.AppointmentDetails)
                .ThenInclude(d => d.AppointmentDetailDates)
                .OrderByDescending(a => a.Date)
                .ToListAsync();
        }

    }
}

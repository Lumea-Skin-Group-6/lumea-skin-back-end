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
    public class AppointmentDetailDateRepository : IAppointmentDetailDateRepository
    {
        private readonly AppDbContext _context;
        public AppointmentDetailDateRepository(AppDbContext context) => _context = context;
        public async Task DeleteDateAsync(int id)
        {
            var date = await _context.AppointmentDetailDates.FindAsync(id);
            if (date != null)
            {
                _context.AppointmentDetailDates.Remove(date);
                await _context.SaveChangesAsync();
            }
        }
    }
}

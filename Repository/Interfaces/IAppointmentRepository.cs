using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<bool> IsSlotAvailableAsync(int? therapistId, DateTime startTime, TimeSpan duration);
        Task BookSlotsAsync(int? therapistId, DateTime startTime, TimeSpan duration);
        Task<Appointment?> AddAppointmentAsync(Appointment appointment);
        Task<Appointment?> UpdateAppointmentAsync(Appointment appointment);
        Task<Appointment?> GetAppointmentByIdAsync(int id);
        Task<IEnumerable<Appointment>> GetAllAppointmentAsync();
        Task<bool> CancelAppointment(int id); 

    }
}

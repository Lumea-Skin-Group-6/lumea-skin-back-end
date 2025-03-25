using BusinessObject;
using DAL.DTOs.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAppointmentService
    {
        Task<Appointment> CreateAppointmentAsync(CreateAppointmentDTO dto);
        Task<Appointment?> UpdateAppointmentAsync(UpdateAppointmentDTO appointment);
        Task<Appointment?> GetAppointmentByIdAsync(int id);
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
    }
}

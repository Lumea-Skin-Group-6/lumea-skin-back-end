using BusinessObject;
using DAL.DTOs.RequestModel;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepo;
        private readonly IAppointmentDetailDateRepository _appointmentDetailDateRepository;
        public AppointmentService(IAppointmentRepository appointmentRepo, IAppointmentDetailDateRepository appointmentDetailDateRepository)
        { 
            _appointmentRepo = appointmentRepo; 
            _appointmentDetailDateRepository = appointmentDetailDateRepository;
        }

        public async Task<Appointment> CreateAppointmentAsync(CreateAppointmentDTO dto)
        {
            TimeZoneInfo vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            DateTime vietnamTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, vietnamTimeZone);
            decimal amount = 0;
            var appointment = new Appointment
            {
                AccountId = dto.AccountId,
                Note = dto.Note,
                Status = "Booked",
                Date = DateTime.UtcNow,
                AppointmentDetails = new List<AppointmentDetail>()
            };

            foreach (var serviceDto in dto.Services)
            {
                if (serviceDto.TherapistId != null)
                {
                    foreach (var dateDto in serviceDto.AppointmentDates)
                    {
                        bool isAvailable = await _appointmentRepo.IsSlotAvailableAsync(serviceDto.TherapistId, dateDto.Date, serviceDto.Duration);
                        if (!isAvailable)
                        {
                            return null;
                        }
                    }
                }              
            }

            foreach (var serviceDto in dto.Services)
            {
                amount = amount + serviceDto.Price;
                var appointmentDetail = new AppointmentDetail
                {                
                    ServiceId = serviceDto.ServiceId,
                    TherapistId = serviceDto.TherapistId,
                    Price = serviceDto.Price,
                    Type = serviceDto.Type,
                    Status = "Scheduled",
                    AppointmentDetailDates = new List<AppointmentDetailDate>()
                };

                foreach (var dateDto in serviceDto.AppointmentDates)
                {
                    if (serviceDto.TherapistId != null)
                    {
                        await _appointmentRepo.BookSlotsAsync(serviceDto.TherapistId, dateDto.Date, serviceDto.Duration);
                    }                   
                    appointmentDetail.AppointmentDetailDates.Add(new AppointmentDetailDate { Date = dateDto.Date });
                }

                appointment.AppointmentDetails.Add(appointmentDetail);
            }
            appointment.Amount = amount;

            var addedAppointment = await _appointmentRepo.AddAppointmentAsync(appointment);
            appointment.Date = vietnamTime;
            return addedAppointment;
        }

        public async Task<Appointment?> UpdateAppointmentAsync(UpdateAppointmentDTO updateDto)
        {
            var existingAppointment = await _appointmentRepo.GetAppointmentByIdAsync(updateDto.Id);

            if (existingAppointment == null)
            {
                return null; // Appointment not found
            }

            // Update appointment fields
            existingAppointment.Note = updateDto.Note;
            existingAppointment.Status = updateDto.Status;

            foreach (var updateDetail in updateDto.Services)
            {
                var existingDetail = existingAppointment.AppointmentDetails
                    .FirstOrDefault(d => d.Id == updateDetail.Id);

                if (existingDetail != null)
                {
                    bool therapistChanged = existingDetail.TherapistId != updateDetail.TherapistId;

                    // If therapist changed, check slot availability before updating
                    if (therapistChanged && updateDetail.TherapistId != null)
                    {
                        foreach (var dateDto in updateDetail.AppointmentDates)
                        {
                            bool isAvailable = await _appointmentRepo.IsSlotAvailableAsync(
                                updateDetail.TherapistId, dateDto.Date, updateDetail.Duration);

                            if (!isAvailable)
                            {
                                return null; // Return null if any slot is unavailable
                            }
                        }
                    }

                    // If therapist changed, release old slots
                    if (therapistChanged && existingDetail.TherapistId != null)
                    {
                        foreach (var oldDate in existingDetail.AppointmentDetailDates)
                        {
                            await _appointmentRepo.ReleaseSlotAsync(existingDetail.TherapistId, oldDate.Date, updateDetail.Duration);
                        }
                    }

                    // Update therapist and status
                    existingDetail.TherapistId = updateDetail.TherapistId;
                    existingDetail.Status = updateDetail.Status;

                    // Handle AppointmentDetailDates
                    var existingDates = existingDetail.AppointmentDetailDates.Select(d => d.Date).ToList();
                    var newDates = updateDetail.AppointmentDates.Select(d => d.Date).ToList();

                    // Remove old dates not in the new list
                    var datesToRemove = existingDetail.AppointmentDetailDates
                        .Where(d => !newDates.Contains(d.Date))
                        .ToList();

                    foreach (var date in datesToRemove)
                    {
                        await _appointmentDetailDateRepository.DeleteDateAsync(date.Id);
                        if (existingDetail.TherapistId != null)
                        {
                            await _appointmentRepo.ReleaseSlotAsync(existingDetail.TherapistId, date.Date, updateDetail.Duration);
                        }
                    }

                    // Add new dates not in the existing list
                    var datesToAdd = newDates.Except(existingDates).ToList();
                    foreach (var newDate in datesToAdd)
                    {
                        var newDetailDate = new AppointmentDetailDate
                        {
                            AppointmentDetailId = existingDetail.Id,
                            Date = newDate
                        };

                        existingDetail.AppointmentDetailDates.Add(newDetailDate);

                        if (updateDetail.TherapistId != null)
                        {
                            await _appointmentRepo.BookSlotsAsync(updateDetail.TherapistId, newDate, updateDetail.Duration);
                        }
                    }
                }
            }

            return await _appointmentRepo.UpdateAppointmentAsync(existingAppointment);
        }



        public async Task<Appointment?> GetAppointmentByIdAsync(int id)
        {
            var appointment =  await _appointmentRepo.GetAppointmentByIdAsync(id);
            if (appointment != null)
            {
                TimeZoneInfo vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                DateTime vietnamTime = TimeZoneInfo.ConvertTimeFromUtc(appointment.Date, vietnamTimeZone);
                appointment.Date = vietnamTime;
            }        
            return appointment;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            TimeZoneInfo vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            var appointmentList = await _appointmentRepo.GetAllAppointmentAsync();
            foreach (var appointment in appointmentList)
            {
                DateTime vietnamTime = TimeZoneInfo.ConvertTimeFromUtc(appointment.Date, vietnamTimeZone);
                appointment.Date = vietnamTime;
            }
            return appointmentList;
        }

        public async Task<bool> CancelAppointment(int id)
        {
            return await _appointmentRepo.CancelAppointment(id);
        }

        public async Task<List<Appointment>> GetAppointmentHistoryAsync(int userId)
        {
            return await _appointmentRepo.GetAppointmentHistoryByUserIdAsync(userId);
        }
    }

}

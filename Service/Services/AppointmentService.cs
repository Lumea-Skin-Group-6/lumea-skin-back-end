﻿using BusinessObject;
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
        public AppointmentService(IAppointmentRepository appointmentRepo) => _appointmentRepo = appointmentRepo;

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

        public async Task<Appointment?> UpdateAppointmentAsync(UpdateAppointmentDTO dto)
        {
            var appointment = new Appointment
            {
                Id = dto.Id,
                Amount = dto.Amount,
                Note = dto.Note,
                Status = dto.Status,
                Date = dto.Date,
                AppointmentDetails = new List<AppointmentDetail>()
            };

            foreach (var serviceDto in dto.Services)
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

            foreach (var serviceDto in dto.Services)
            {
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
                    await _appointmentRepo.BookSlotsAsync(serviceDto.TherapistId, dateDto.Date, serviceDto.Duration);
                    appointmentDetail.AppointmentDetailDates.Add(new AppointmentDetailDate { Date = dateDto.Date });
                }

                appointment.AppointmentDetails.Add(appointmentDetail);
            }

            var updatedAppointment = await _appointmentRepo.UpdateAppointmentAsync(appointment);
            if (updatedAppointment != null)
            {
                TimeZoneInfo vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                DateTime vietnamTime = TimeZoneInfo.ConvertTimeFromUtc(updatedAppointment.Date, vietnamTimeZone);
                updatedAppointment.Date = vietnamTime;
            }         
            return updatedAppointment;
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
    }

}

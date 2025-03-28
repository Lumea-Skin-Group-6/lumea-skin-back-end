﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.RequestModel
{
    public class CreateAppointmentDTO
    {
        public int AccountId { get; set; }
        public string? Note { get; set; }
        public List<AppointmentDetailDTO> Services { get; set; }
    }

    public class UpdateAppointmentDTO
    {
        public int Id { get; set; }
        public string? Note { get; set; }
        public string Status { get; set; }
        public List<UpdateAppointmentDetailDTO> Services { get; set; }
    }

    public class UpdateAppointmentDetailDTO
    {
        public int Id { get; set; } // For existing details
        public int? TherapistId { get; set; }
        public string Status { get; set; }
        public TimeSpan Duration { get; set; }
        public List<UpdateAppointmentDetailDateDTO> AppointmentDates { get; set; }
    }

    public class UpdateAppointmentDetailDateDTO
    {
        public DateTime Date { get; set; }
    }

    public class AppointmentDetailDTO
    {
        public int ServiceId { get; set; }
        public int? TherapistId { get; set; }
        public decimal Price { get; set; }
        public ServiceType Type { get; set; }
        public TimeSpan Duration { get; set; }
        public List<AppointmentDetailDateDTO> AppointmentDates { get; set; }
    }

    public class AppointmentDetailDateDTO
    {
        public DateTime Date { get; set; }
    }
}

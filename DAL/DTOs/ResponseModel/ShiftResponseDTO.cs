using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.DTOs.ResponseModel
{
    public class ShiftResponseDTO
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }


        public DateTime StartTime { get; set; }


        public DateTime EndTime { get; set; }


        public int MinStaff { get; set; }


        public int MaxStaff { get; set; }


        public int MinTherapist { get; set; }


        public int MaxTherapist { get; set; }


        public string Status { get; set; }


        public ShiftResponseDTO(string name, DateTime date, DateTime startTime, DateTime endTime, int minStaff,
            int maxStaff, int minTherapist, int maxTherapist, string status)
        {
            Name = name;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            MinStaff = minStaff;
            MaxStaff = maxStaff;
            MinTherapist = minTherapist;
            MaxTherapist = maxTherapist;
            Status = status;
        }

        public ShiftResponseDTO()
        {
        }
    }
}
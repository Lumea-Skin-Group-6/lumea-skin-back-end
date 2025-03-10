using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.RequestModel
{
    public class ShiftRequestDTO
    {
        public string Name { get; set; }

        public DateTime StartTime { get; set; }


        public DateTime EndTime { get; set; }


        public int MinStaff { get; set; }


        public int MaxStaff { get; set; }


        public int MinTherapist { get; set; }


        public int MaxTherapist { get; set; }


        public string Status { get; set; }
    }
}
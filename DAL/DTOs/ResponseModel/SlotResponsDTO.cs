using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.ResponseModel
{
    public class SlotResponsDTO
    {
        public Employee Employee { get; set; }

        public string Time {  get; set; }

        public string Status { get; set; } 

        public DateTime DateTime { get; set; }

        public SlotResponsDTO(Employee employee, string time, string status, DateTime dateTime)
        {
            Employee = employee;
            Time = time;
            Status = status;
            DateTime = dateTime;
        }
    }
}

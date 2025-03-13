using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.RequestModel
{
    public class TherapistRequest
    {

        public ICollection<int> AccountId { get; set; }
        public string Type { get; set; }
    }
}

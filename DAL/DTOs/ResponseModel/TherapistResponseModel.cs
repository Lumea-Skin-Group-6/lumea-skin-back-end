using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.ResponseModel
{
    public class TherapistExpertiseResponseModel
    {
        public int ExpertiseId { get; set; }
        public string ExpertiseName { get; set; } = "";
        public int Experience { get; set; }
    }
    public class TherapistResponseModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
        public string? ImageUrl { get; set; }
        public bool Gender { get; set; }
        public string Phone { get; set; } = "";
        public int RoleId { get; set; }
        public string RoleName { get; set; } = "";
        public string Status { get; set; } = "";

        public int? TherapistID { get; set; } 
        public IEnumerable<TherapistExpertiseResponseModel> Expertises { get; set; } = [];
    }
}

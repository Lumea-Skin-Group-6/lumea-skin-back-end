using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.RequestModel
{
    public class AddTherapistExpertiseRequestModel
    {
        [Required(ErrorMessage = "Expertise ID is required.")]
        public int ExpertiseId { get; set; }
        [Range(0, 50, ErrorMessage = "Experience must be between 0 and 50 years.")]
        public int Experience { get; set; }
    }

    public class AddTherapistRequestModel
    {
        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(100, ErrorMessage = "Full Name cannot exceed 100 characters.")]
        public string FullName { get; set; } = "";

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public bool Gender { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string Phone { get; set; } = "";

        [Required(ErrorMessage = "Role ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Role ID must be a positive integer.")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [StringLength(50, ErrorMessage = "Status cannot exceed 50 characters.")]
        public string Status { get; set; } = "";
        [MinLength(1, ErrorMessage = "At least one expertise is required.")]
        public IEnumerable<AddTherapistExpertiseRequestModel> TherapistExpertises { get; set; } = [];
    }
}

using System.ComponentModel.DataAnnotations;

namespace DAL.DTOs.RequestModel;

public class VerifyOtpRequestModel
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "OTP cannot be empty.")]
    public string Otp { get; set; } = string.Empty;
}
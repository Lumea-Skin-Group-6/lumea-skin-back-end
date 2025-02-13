using DAL.DTO.RequestModel;


namespace Service.Interfaces;

public interface IAuthService
{
    Task<string> SeedRolesAsync();
    Task Register(UserRegistrationRequestModel userDto);
    Task VerifyOtp(string email, string otp);
}
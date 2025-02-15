using DAL.DTO.RequestModel;
using DAL.DTOs.ResponseModel;


namespace Service.Interfaces;

public interface IAuthService
{
    Task<string> SeedRolesAsync();
    Task Register(UserRegistrationRequestModel userDto);
    Task VerifyOtp(string email, string otp);
    Task<UserAuthenticationResponse> LoginAsync(string email, string password);
    Task<UserAuthenticationResponse> RefreshTokenAsync(string refreshToken);
}
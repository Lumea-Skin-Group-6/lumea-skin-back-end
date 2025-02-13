using System.Net;
using DAL.DTO.RequestModel;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using SkincareBookingApp.Helpers;

namespace SkincareBookingApp.Controllers;

[ApiController]
[Route("api/auth")]
[ApiExplorerSettings(GroupName = "Authentication")]
public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService service)
    {
        _authService = service;
    }

    [HttpGet("init-roles")]
    public async Task<IActionResult> InitializeRoles()
    {
        var result = await _authService.SeedRolesAsync();
        return Ok(result);
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegistrationRequestModel userDto)
    {
        await _authService.Register(userDto);
        return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.Accepted, "Successfully Register",
            "Please check your email for account verification.");
    }

    [HttpPost("verify-otp")]
    public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpRequestModel request)
    {
        await _authService.VerifyOtp(request.Email, request.Otp);
        return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "OTP Verified", "Your account is now active.");
    }
}
using System.Net;
using Azure;
using DAL.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
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
    public IActionResult Register(UserRegistrationRequestModel userDto)
    {
        _authService.Register(userDto);
        return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.Accepted, "Successfully Register",
            "Please check your email for account verification.");
    }
}
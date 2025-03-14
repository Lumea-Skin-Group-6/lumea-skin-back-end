using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using SkincareBookingApp.Helpers;

namespace SkincareBookingApp.Controllers;

[ApiController]
[Route("api/setting")]
[ApiExplorerSettings(GroupName = "Account Settings")]
public class AccountController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;

    public AccountController(IConfiguration configuration, IUserService userService)
    {
        _configuration = configuration;
        _userService = userService;
    }

    [Authorize]
    [HttpGet("account/{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        try
        {
            var user = await _userService.GetUserByIdAsync(id);
            return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.Accepted, "Successfully Retrieve Account Information",
                user);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}
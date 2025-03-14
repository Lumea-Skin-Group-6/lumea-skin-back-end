﻿using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using DAL.DTOs.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using SkincareBookingApp.Helpers;

namespace SkincareBookingApp.Controllers;

[ApiController]
[Route("api/auth")]
[ApiExplorerSettings(GroupName = "Authentication")]
public class AuthController : Controller
{
    private readonly IAuthService _authService;

    private readonly IConfiguration _configuration;
    public AuthController(IAuthService service, IConfiguration configuration)
    {
        _authService = service;
        _configuration = configuration;
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
        try
        {
            await _authService.VerifyOtp(request.Email, request.Otp);
            return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "OTP Verified",
                "Your account is now active.");
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequestModel request)
    {
        try
        {
            var authResponse = await _authService.LoginAsync(request.Email, request.Password);

            var responseObject = new
            {
                access_token = authResponse.AccessToken,
                refresh_token = authResponse.RefreshToken
            };

            return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Login successful", responseObject);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [Authorize]
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestModel request)
    {
        try
        {
            var authResponse = await _authService.RefreshTokenAsync(request.RefreshToken);
            return Ok(new
            {
                access_token = authResponse.AccessToken,
                refresh_token = authResponse.RefreshToken
            });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                new { message = "An error occurred while refreshing the token.", error = ex.Message });
        }
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] RefreshTokenRequestModel request)
    {
        try
        {
            await _authService.LogoutAsync(request.RefreshToken);
            return CustomSuccessHandler.ResponseBuilder(HttpStatusCode.OK, "Logout successful",
                "You have been logged out.");
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while logging out.", error = ex.Message });
        }
    }

    [HttpGet("get-user-info")]
    public IActionResult DecodeToken()
    {
        try
        {
            var authHeader = HttpContext.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            {
                return BadRequest(new { error = "Authorization header is missing or invalid" });
            }

            var token = authHeader.Substring("Bearer ".Length).Trim();

            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
            var tokenHandler = new JwtSecurityTokenHandler();

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = key
            };

            var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
            var jwtToken = (JwtSecurityToken)validatedToken;

            var claims = jwtToken.Claims.ToDictionary(c => c.Type, c => c.Value);

            return Ok(new { claims });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

}
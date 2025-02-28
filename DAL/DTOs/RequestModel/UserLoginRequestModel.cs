﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DAL.DTOs.RequestModel;

public class UserLoginRequestModel
{
    [JsonPropertyName("email")]
    [Required(ErrorMessage = "Email cannot be blank")]
    public string Email { get; set; } = string.Empty;

    [JsonPropertyName("password")]
    [Required(ErrorMessage = "Password cannot be blank")]
    public string Password { get; set; } = string.Empty;
}
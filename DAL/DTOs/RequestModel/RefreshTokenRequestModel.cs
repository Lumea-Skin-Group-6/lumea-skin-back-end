using System.Text.Json.Serialization;

namespace DAL.DTOs.RequestModel;

public class RefreshTokenRequestModel
{
    [JsonPropertyName("refreshToken")] public string RefreshToken { get; set; }
}
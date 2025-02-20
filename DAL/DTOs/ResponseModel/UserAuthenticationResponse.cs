using System.Text.Json.Serialization;

namespace DAL.DTOs.ResponseModel;

public class UserAuthenticationResponse
{
    [JsonPropertyName("accessToken")] public string AccessToken { get; set; }

    [JsonPropertyName("refreshToken")] public string RefreshToken { get; set; }
}
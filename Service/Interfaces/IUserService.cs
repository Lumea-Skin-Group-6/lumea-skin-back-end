using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;

namespace Service.Interfaces;

public interface IUserService
{
    Task<UserProfileResponseModel?> GetUserByIdAsync(int id);
    Task<bool> UpdateUserAsync(int id, UpdateUserRequestModel model);
    public Task<bool> UpdateUserImageAsync(int id, string imageUrl);
}
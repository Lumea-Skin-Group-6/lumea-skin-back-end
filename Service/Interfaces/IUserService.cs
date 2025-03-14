using DAL.DTOs.ResponseModel;

namespace Service.Interfaces;

public interface IUserService
{
    Task<UserProfileResponseModel?> GetUserByIdAsync(int id);
}
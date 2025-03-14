using DAL.DTOs.ResponseModel;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserProfileResponseModel?> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
        {
            throw new KeyNotFoundException("User not found.");
        }

        return new UserProfileResponseModel
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            DateOfBirth = user.DateOfBirth,
            ImageUrl = user.ImageUrl,
            Gender = user.Gender,
            Phone = user.Phone,
            Status = user.Status,
            IsLoggedIn = user.IsLoggedIn,
            Role = new UserProfileResponseModel.RoleDto
            {
                Id = user.Role.Id,
                Name = user.Role.Name
            }
        };
    }
}
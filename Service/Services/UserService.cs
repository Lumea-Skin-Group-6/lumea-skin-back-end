using DAL.DTOs.RequestModel;
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
        };
    }

    public async Task<bool> UpdateUserAsync(int id, UpdateUserRequestModel model)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) throw new KeyNotFoundException("User not found.");

        user.FullName = model.FullName;
        user.Email = model.Email;
        user.DateOfBirth = model.DateOfBirth;
        user.ImageUrl = model.ImageUrl;
        user.Gender = model.Gender;
        user.Phone = model.Phone;

        await _userRepository.UpdateAsync(user);
        return true;
    }

    public async Task<bool> UpdateUserImageAsync(int id, string imageUrl)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) throw new KeyNotFoundException("User not found.");

        user.ImageUrl = imageUrl;
        await _userRepository.UpdateAsync(user);

        return true;
    }
}
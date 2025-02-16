using BusinessObject;
using DAL.DTO;
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
}
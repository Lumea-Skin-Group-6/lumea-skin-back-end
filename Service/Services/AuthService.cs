using System.Security.Cryptography;
using System.Text;
using BusinessObject;
using DAL.DTO.RequestModel;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces;
using Service.Interfaces;

namespace Service.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IMailService _mailService;
    private readonly IConfiguration _configuration;
    private readonly string _emailSecureCharacters;

    public AuthService(IUserRepository userRepository, IRoleRepository roleRepository, IMailService mailService,
        IConfiguration configuration)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _mailService = mailService;
        _configuration = configuration;
        _emailSecureCharacters = _configuration["MailSettings:SecureCharacters"] ?? "";
    }

    public async Task<string> SeedRolesAsync()
    {
        var existingRoles = await _roleRepository.GetAllAsync();

        if (existingRoles.Any())
        {
            return "Roles are already initialized.";
        }

        var roles = new List<Role>
        {
            new Role { Name = "Manager" },
            new Role { Name = "Staff" },
            new Role { Name = "Customer" },
            new Role { Name = "Therapist" }
        };

        foreach (var role in roles)
        {
            await _roleRepository.CreateAsync(role);
        }

        return "Roles initialized successfully.";
    }

    public async Task Register(UserRegistrationRequestModel userDto)
    {
        var existingUser = await _userRepository.GetByEmailAsync(userDto.Email);
        if (existingUser != null)
        {
            throw new Exception("Account already exists.");
        }

        var customerRole = await _roleRepository.GetByNameAsync("Customer");

        if (customerRole == null)
        {
            throw new Exception("Customer role does not exist. Please initialize roles first.");
        }

        string verificationCode = GenerateActivationCode();

        var account = new Account
        {
            Email = userDto.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
            FullName = userDto.FullName,
            DateOfBirth = userDto.DateOfBirth,
            Phone = userDto.Phone,
            Gender = userDto.Gender,
            Status = "inactive",
            RoleId = customerRole.Id,
            ImageUrl = null,
            ActivationCode = verificationCode,
            IsLoggedIn = false,
            IsDeleted = false
        };


        await _userRepository.CreateAsync(account);
        string subject = "Your Verification Code";
        string message = $"<h2>Welcome to Our Service</h2><p>Your verification code is: <b>{verificationCode}</b></p>";
        await _mailService.SendEmailVerificationCode(userDto.Email, subject, message);
    }

    private string GenerateActivationCode()
    {
        StringBuilder codeBuilder = new StringBuilder();
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            byte[] randomBytes = new byte[1];

            for (int i = 0; i < 6; i++)
            {
                rng.GetBytes(randomBytes);
                int randomIndex = randomBytes[0] % _emailSecureCharacters.Length;
                codeBuilder.Append(_emailSecureCharacters[randomIndex]);
            }
        }

        return codeBuilder.ToString();
    }

    public async Task VerifyOtp(string email, string otp)
    {
        if (string.IsNullOrWhiteSpace(otp))
        {
            throw new Exception("OTP cannot be empty.");
        }

        var user = await _userRepository.GetByEmailAsync(email);
        if (user == null)
        {
            throw new Exception("Account not found.");
        }

        if (user.ActivationCode != otp)
        {
            throw new Exception("Incorrect OTP. Please try again.");
        }

        user.Status = "active";
        user.ActivationCode = null;
        await _userRepository.UpdateAsync(user);
    }
}
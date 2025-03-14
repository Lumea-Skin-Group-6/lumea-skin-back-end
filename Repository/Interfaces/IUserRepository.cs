using BusinessObject;

namespace Repository.Interfaces;

public interface IUserRepository
{
    Task<Account> CreateAsync(Account account);
    Task<Account?> GetByEmailAsync(string email);
    Task UpdateAsync(Account account);
    Task<Account> GetByRefreshTokenAsync(string refreshToken);
    List<Account> GetAll();

    Account GetAccountById(int id);
    Task<Account?> GetByIdAsync(int id);
    Task<bool> ExistsAsync(int id);
}
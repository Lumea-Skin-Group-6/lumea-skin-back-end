using BusinessObject;

namespace Repository.Interfaces;

public interface IUserRepository
{
    Task<Account> CreateAsync(Account account);
    Task<Account?> GetByEmailAsync(string email);
    Task UpdateAsync(Account account);
}
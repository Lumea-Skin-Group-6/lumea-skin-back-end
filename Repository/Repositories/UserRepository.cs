using BusinessObject;
using DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Account?> GetByEmailAsync(string email)
    {
        return await _context.Accounts.FirstOrDefaultAsync(a => a.Email == email);
    }

    public async Task<Account> CreateAsync(Account account)
    {
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();
        return account;
    }

    public async Task UpdateAsync(Account account)
    {
        _context.Accounts.Update(account);
        await _context.SaveChangesAsync();
    }
}
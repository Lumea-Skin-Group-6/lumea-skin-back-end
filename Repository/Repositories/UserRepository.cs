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
        return await _context.Accounts
            .Include(a => a.Role)
            .FirstOrDefaultAsync(a => a.Email == email);
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

    public async Task<Account> GetByRefreshTokenAsync(string refreshToken)
    {
        var user = await _context.Accounts.Include(a => a.Role)
            .Where(u => u.RefreshToken.Trim().ToLower() == refreshToken.Trim().ToLower())
            .FirstOrDefaultAsync();
        return user;
    }

    public List<Account> GetAll()
    {
        return _context.Accounts.ToList();
    }

    public async Task<Account?> GetByIdAsync(int id)
    {
        return await _context.Accounts
            .Include(a => a.Role)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Accounts.AnyAsync(a => a.Id == id);
    }
}
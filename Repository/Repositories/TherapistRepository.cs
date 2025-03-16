using BusinessObject;
using DAL.DBContext;
using DAL.Migrations;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class TherapistRepository : ITherapistRepository
    {

        private readonly AppDbContext _context;

        public TherapistRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Account> AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<Account> DeleteAsync(int id)
        {
            Account? account = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id);
            if (account == null)
            {
                throw new InvalidOperationException("Therapist not found.");
            }

            var therapistExpertises = await _context.TherapistExpertises.Where(x => x.therapist_id == account.Id).ToListAsync();
            foreach (var item in therapistExpertises)
            {
                _context.TherapistExpertises.Remove(item);
            }

            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.AccountId == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _context.Accounts
                .Where(x => x.RoleId == 5)
                .Include(x => x.Role)
                .Include(x => x.Employee)
                .ThenInclude(x => x.TherapistExpertises)
                .ThenInclude(x => x.expertise)
                .ToListAsync();
        }

        public async Task<Account?> GetByIdAsync(int id)
        {
            return await _context.Accounts
              .Where(x => x.RoleId == 5)
              .Include(x => x.Role)
              .Include(x => x.Employee)
              .ThenInclude(x => x.TherapistExpertises)
              .ThenInclude(x => x.expertise)
              .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Account> UpdateAsync(Account account)
        {
            var existingEmployee = await _context.Employees.FirstOrDefaultAsync(x => x.AccountId != account.Id);
            if (existingEmployee == null)
            {
                throw new InvalidOperationException("Therapist not found.");
            }
            var existingAccount = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == account.Id);
            if (existingAccount == null)
            {
                throw new InvalidOperationException("Therapist not found.");
            }
            var therapistExpertises = await _context.TherapistExpertises.Where(x => x.therapist_id == account.Id).ToListAsync();
            foreach (var item in therapistExpertises)
            {
                _context.TherapistExpertises.Remove(item);
            }

            foreach (var item in account.Employee?.TherapistExpertises ?? [])
            {
                await _context.TherapistExpertises.AddAsync(item);
            }

            existingAccount.Status = account.Status;
            existingAccount.Email = account.Email;
            existingAccount.DateOfBirth = account.DateOfBirth;
            existingAccount.Phone = account.Phone;
            existingAccount.FullName = account.FullName;
            existingAccount.ImageUrl = account.ImageUrl;
            existingAccount.Gender = account.Gender;

            await _context.SaveChangesAsync();
            return account;
        }
    }
}

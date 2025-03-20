using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using DAL.Mappers;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<AccountResponseModel> AddAsync(AddAccountRequestModel requestModel)
        {
            var accounts = await _accountRepository.GetAllAsync();
            if (accounts.FirstOrDefault(x => x.Email.ToLower() == requestModel.Email.ToLower()) != null)
            {
                throw new InvalidOperationException("Account email must be unique");
            }
            requestModel.Password = BCrypt.Net.BCrypt.HashPassword(requestModel.Password);
            var result = await _accountRepository.AddAsync(requestModel.ToAccount());
            return result.ToAccountResponseModel();
        }

        public async Task<AccountResponseModel> DeleteAsync(int id)
        {
            var result = await _accountRepository.DeleteAsync(id);
            return result.ToAccountResponseModel();
        }

        public async Task<IEnumerable<AccountResponseModel>> GetAllAsync()
        {
            var result = await _accountRepository.GetAllAsync();
            return result.Select(x => x.ToAccountResponseModel());
        }

        public async Task<AccountResponseModel> GetByIdAsync(int id)
        {
            var result = await _accountRepository.GetByIdAsync(id);
            if (result == null) throw new KeyNotFoundException();
            return result.ToAccountResponseModel();
        }

        public async Task<AccountResponseModel> UpdateAsync(int id, UpdateAccountRequestModel requestModel)
        {
            var accounts = await _accountRepository.GetAllAsync();
            if (accounts.FirstOrDefault(x => x.Email.ToLower() == requestModel.Email.ToLower()) != null)
            {
                throw new InvalidOperationException("Account email must be unique");
            }
            var result = await _accountRepository.UpdateAsync(requestModel.ToAccount(id));
            return result.ToAccountResponseModel();
        }
    }
}

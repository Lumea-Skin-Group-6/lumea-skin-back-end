using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountResponseModel>> GetAllAsync();
        Task<AccountResponseModel> GetByIdAsync(int id);
        Task<AccountResponseModel> AddAsync(AddAccountRequestModel requestModel);
        Task<AccountResponseModel> UpdateAsync(int id, UpdateAccountRequestModel requestModel);
        Task<AccountResponseModel> DeleteAsync(int id);
    }
}

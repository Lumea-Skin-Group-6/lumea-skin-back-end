using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceResponseModel>> GetAllAsync();
        Task<ServiceResponseModel> GetByIdAsync(int id);
        Task<ServiceResponseModel> AddAsync(AddServiceRequestModel requestModel);
        Task<ServiceResponseModel> UpdateAsync(int id, UpdateServiceRequestModel requestModel);
        Task<ServiceResponseModel> DeleteAsync(int id);
    }
}

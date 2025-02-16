using BusinessObject;
using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IExpertiseService
    {
        Task<IEnumerable<ExpertiseResponseModel>> GetAllAsync();
        Task<ExpertiseResponseModel> GetByIdAsync(int id);
        Task<ExpertiseResponseModel> AddAsync(AddExpertiseRequestModel requestModel);
        Task<ExpertiseResponseModel> UpdateAsync(int id, UpdateExpertiseRequestModel requestModel);
        Task<ExpertiseResponseModel> DeleteAsync(int id);
    }
}

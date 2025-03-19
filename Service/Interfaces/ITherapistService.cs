using BusinessObject;
using DAL.DTO;
using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITherapistService
    {
        Task<IEnumerable<TherapistResponseModel>> GetAllAsync();
        Task<TherapistResponseModel> GetByIdAsync(int id);
        Task<TherapistResponseModel> AddAsync(AddTherapistRequestModel requestModel);
        Task<TherapistResponseModel> UpdateAsync(int id, UpdateTherapistRequestModel requestModel);
        Task<TherapistResponseModel> DeleteAsync(int id);
    }
}

using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ISkinTypeService
    {
        Task<IEnumerable<SkinTypeResponseModel>> GetAllAsync();
        Task<SkinTypeResponseModel> GetByIdAsync(int id);
        Task<SkinTypeResponseModel> AddAsync(AddSkinTypeRequestModel requestModel);
        Task<SkinTypeResponseModel> UpdateAsync(int id, UpdateSkinTypeRequestModel requestModel);
        Task<SkinTypeResponseModel> DeleteAsync(int id);
    }
}

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
        IEnumerable<ExpertiseResponseModel> GetAll();
        ExpertiseResponseModel? GetById(int id);
        void Add(AddExpertiseRequestModel expertise);
        void Update(int id, UpdateExpertiseRequestModel expertise);
        void Delete(int id);
    }
}

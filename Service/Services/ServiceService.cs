using BusinessObject;
using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _repository;

        public ServiceService(IServiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResponseModel> AddAsync(AddServiceRequestModel requestModel)
        {
            var services = await _repository.GetAllAsync();
            var existingService = services.FirstOrDefault(x => x.Name == requestModel.Name);
            if (existingService != null)
            {
                throw new InvalidOperationException("Service name must be unique");
            }
            var result = await _repository.AddAsync(new BusinessObject.Service
            {
                Name = requestModel.Name,

            });
            return new ServiceResponseModel
            {
                Name = requestModel.Name,
            };
        }

        public Task<ServiceResponseModel> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ServiceResponseModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponseModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponseModel> UpdateAsync(int id, UpdateExpertiseRequestModel requestModel)
        {
            throw new NotImplementedException();
        }
    }
}

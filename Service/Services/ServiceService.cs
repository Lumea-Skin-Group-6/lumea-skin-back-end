using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using DAL.Mappers;
using Repository;
using Repository.Interfaces;


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

            var result = await _repository.AddAsync(requestModel.ToService());
            return result.ToServiceResponseModel();
        }

        public async Task<ServiceResponseModel> DeleteAsync(int id)
        {
            var service = await _repository.GetByIdAsync(id);
            if (service == null)
            {
                throw new KeyNotFoundException("Service not found.");
            }

            var result = await _repository.DeleteAsync(id);
            return result.ToServiceResponseModel();
        }

        public async Task<IEnumerable<ServiceResponseModel>> GetAllAsync()
        {
            var services = await _repository.GetAllAsync();
            return services.Select(e => e.ToServiceResponseModel());
        }

        public async Task<ServiceResponseModel> GetByIdAsync(int id)
        {
            var service = await _repository.GetByIdAsync(id);
            if (service == null)
            {
                throw new KeyNotFoundException("Service not found.");
            }

            return service.ToServiceResponseModel();
        }

        public async Task<ServiceResponseModel> UpdateAsync(int id, UpdateServiceRequestModel requestModel)
        {
            var existingService = await _repository.GetByIdAsync(id);
            if (existingService == null)
            {
                throw new KeyNotFoundException("Service not found.");
            }

            var services = await _repository.GetAllAsync();

            existingService = services.FirstOrDefault(x => x.Name == requestModel.Name && x.Id != id);
            if (existingService != null)
            {
                throw new InvalidOperationException("Service name must be unique");
            }

            var result = await _repository.UpdateAsync(requestModel.ToService(id));
            return result.ToServiceResponseModel();
        }
    }
}
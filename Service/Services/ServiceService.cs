using BusinessObject;
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

        private readonly IExpertiseRepository _expertiseRepository;

        private readonly IServiceExpertiseRepository _serviceExpertiseRepo;


        public ServiceService(IServiceRepository repository, IExpertiseRepository expertiseRepository, IServiceExpertiseRepository serviceExpertiseRepo)
        {
            _repository = repository;
            _expertiseRepository = expertiseRepository;
            _serviceExpertiseRepo = serviceExpertiseRepo;
        }
        public async Task<ServiceResponseModel> AddAsync(AddServiceRequestModel requestModel)
        {
            var services = await _repository.GetAllAsync();
            var existingService = services.FirstOrDefault(x => x.Name == requestModel.Name);
            if (existingService != null)
            {
                throw new InvalidOperationException("Service name must be unique");
            }

            // Lấy tất cả expertise hiện có
            var expertise = await _expertiseRepository.GetAllAsync();
            var existingExpertiseIds = expertise.Select(e => e.Id).ToHashSet();

            // Kiểm tra tất cả ID trong requestModel.ServiceExpertisesID
            var invalidIds = requestModel.ServiceExpertisesID.Where(id => !existingExpertiseIds.Contains(id)).ToList();
            if (invalidIds.Any())
            {
                throw new InvalidOperationException("Expertise not exist: " + string.Join(", ", invalidIds));
            }

            // Nếu tất cả Expertise ID hợp lệ, tiến hành lưu Service
            var result = await _repository.AddAsync(requestModel.ToService());

            // Lưu ServiceExpertise
            foreach (var item in requestModel.ServiceExpertisesID)
            {
                ServiceExpertise serviceExpertise = new ServiceExpertise
                {
                    ServiceId = result.Id,
                    ExpertiseId = item
                };
                _serviceExpertiseRepo.AddServiceExpertise(serviceExpertise);
            }

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
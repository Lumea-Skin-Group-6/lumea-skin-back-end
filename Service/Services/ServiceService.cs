using AutoMapper;
using BusinessObject;
using DAL.DBContext;
using DAL.DTOs.RequestModel;
using DAL.DTOs.ResponseModel;
using DAL.Mappers;
using Repository;
using Repository.Interfaces;


namespace Service.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IExpertiseRepository _expertiseRepository;
        private readonly ISkinTypeRepository _skinTypeRepository;
        private readonly IMapper _mapper;

        public ServiceService(IServiceRepository serviceRepository,
                              IExpertiseRepository expertiseRepository,
                              ISkinTypeRepository skinTypeRepository,
                              IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _expertiseRepository = expertiseRepository;
            _skinTypeRepository = skinTypeRepository;
            _mapper = mapper;
        }


        public async Task<ServiceResponseModel> AddAsync(AddServiceRequestModel request)
        {
            var service = _mapper.Map<ServiceModel>(request);

            service.ServiceExpertises = await ConvertExpertiseIdsToObjects(request.ServiceExpertisesID);

            service.SkinTypeServices = await ConvertSkinTypeIdsToObjects(request.SkinTypeID);

            var createdService = await _serviceRepository.AddAsync(service);
            return _mapper.Map<ServiceResponseModel>(createdService);
        }

        public async Task<ServiceResponseModel> UpdateAsync(int id, UpdateServiceRequestModel request)
        {
            var serviceToUpdate = _mapper.Map<ServiceModel>(request);
            serviceToUpdate.Id = id;

            serviceToUpdate.ServiceExpertises = await ConvertExpertiseIdsToObjects(request.ServiceExpertisesID);

            serviceToUpdate.SkinTypeServices = await ConvertSkinTypeIdsToObjects(request.SkinTypeID);

            var updatedService = await _serviceRepository.UpdateAsync(serviceToUpdate);
            return _mapper.Map<ServiceResponseModel>(updatedService);
        }

        public async Task<IEnumerable<ServiceResponseModel>> GetAllAsync()
        {
            var services = await _serviceRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ServiceResponseModel>>(services);
        }

        public async Task<ServiceResponseModel?> GetByIdAsync(int id)
        {
            var service = await _serviceRepository.GetByIdAsync(id);
            return service == null ? null : _mapper.Map<ServiceResponseModel>(service);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _serviceRepository.DeleteAsync(id);
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        private async Task<List<ServiceExpertise>> ConvertExpertiseIdsToObjects(List<int> expertiseIds)
        {
            var expertises = await _expertiseRepository.GetByIdsAsync(expertiseIds);
            return expertises.Select(e => new ServiceExpertise { ExpertiseId = e.Id }).ToList();
        }

        private async Task<List<SkinTypeService>> ConvertSkinTypeIdsToObjects(List<int> skinTypeIds)
        {
            var skinTypes = await _skinTypeRepository.GetByIdsAsync(skinTypeIds);
            return skinTypes.Select(s => new SkinTypeService { SkinTypeId = s.Id }).ToList();
        }
    }


}
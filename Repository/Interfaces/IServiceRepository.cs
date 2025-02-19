using BusinessObject;

namespace Repository.Interfaces
{
    public interface IServiceRepository
    {
        Task<IEnumerable<ServiceModel>> GetAllAsync();
        Task<ServiceModel?> GetByIdAsync(int id);
        Task<ServiceModel> AddAsync(ServiceModel service);
        Task<ServiceModel> UpdateAsync(ServiceModel service);
        Task<ServiceModel> DeleteAsync(int id);
    }
}
using BusinessObject;


namespace Repository.Interfaces
{
    public interface IExpertiseRepository
    {
        Task<IEnumerable<Expertise>> GetAllAsync();
        Task<Expertise?> GetByIdAsync(int id);
        Task<IEnumerable<Expertise>> GetByIdsAsync(List<int> ids);
        Task<Expertise> AddAsync(Expertise expertise);
        Task<Expertise> UpdateAsync(Expertise expertise);
        Task<Expertise> DeleteAsync(int id);
    }
}
using BusinessObject;


namespace Repository.Interfaces
{
    public interface IExpertiseRepository
    {
        Task<IEnumerable<Expertise>> GetAllAsync();
        Task<Expertise?> GetByIdAsync(int id);
        Task<Expertise> AddAsync(Expertise expertise);
        Task<Expertise> UpdateAsync(Expertise expertise);
        Task<Expertise> DeleteAsync(int id);
    }
}
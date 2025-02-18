using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
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
